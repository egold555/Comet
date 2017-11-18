using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace VixenPlus
{
    public class VixenHTTPServer
    {
        Thread thread;
        HttpServer httpServer;

        public VixenHTTPServer() : this(8080)
        {
            
        }

        public VixenHTTPServer(int port)
        {
            httpServer = new VixenHTTPServerHandler(port);
            thread = new Thread(new ThreadStart(httpServer.listen));
        }

        public void start()
        {
            thread.Start();
        }

        public void stop()
        {
            httpServer.stop();
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class VixenHTTPServerHandler : HttpServer
    {
        IExecution _executionInterface = null;
        public VixenHTTPServerHandler(int port) : base(port)
        {
            object obj2;
            if (Interfaces.Available.TryGetValue("IExecution", out obj2)) {
                _executionInterface = (IExecution)obj2;
                Console.WriteLine("Got IExecution");
            }
        }

        public override void handleGETRequest(HttpProcessor p)
        {
            p.writeSuccess();
            p.writeLine("Get!");
        }

        public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
            string data = inputData.ReadToEnd();
            p.writeSuccess();
            p.writeLine("Post!");
            
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public class HttpProcessor
    {
        public TcpClient socket;
        public HttpServer srv;

        private Stream inputStream;
        public StreamWriter outputStream;

        public String http_method;
        public String http_url;
        public String http_protocol_versionstring;
        public Hashtable httpHeaders = new Hashtable();


        private static int MAX_POST_SIZE = 10 * 1024 * 1024; // 10MB

        public HttpProcessor(TcpClient s, HttpServer srv)
        {
            this.socket = s;
            this.srv = srv;
        }


        private string streamReadLine(Stream inputStream)
        {
            int next_char;
            string data = "";
            while (true) {
                next_char = inputStream.ReadByte();
                if (next_char == '\n') { break; }
                if (next_char == '\r') { continue; }
                if (next_char == -1) { Thread.Sleep(1); continue; };
                data += Convert.ToChar(next_char);
            }
            return data;
        }
        public void process()
        {
           
            inputStream = new BufferedStream(socket.GetStream());

            outputStream = new StreamWriter(new BufferedStream(socket.GetStream()));
            try {
                parseRequest();
                readHeaders();
                if (http_method.Equals("GET")) {
                    handleGETRequest();
                }
                else if (http_method.Equals("POST")) {
                    handlePOSTRequest();
                }
            }
            catch (Exception e) {
                Console.WriteLine("Exception: " + e.ToString());
                writeFailure();
            }
            outputStream.Flush();

            inputStream = null; outputStream = null;           
            socket.Close();
        }

        public void parseRequest()
        {
            String request = streamReadLine(inputStream);
            string[] tokens = request.Split(' ');
            if (tokens.Length != 3) {
                throw new Exception("invalid http request line");
            }
            http_method = tokens[0].ToUpper();
            http_url = tokens[1];
            http_protocol_versionstring = tokens[2];

            Console.WriteLine("starting: " + request);
        }

        public void readHeaders()
        {
            Console.WriteLine("readHeaders()");
            String line;
            while ((line = streamReadLine(inputStream)) != null) {
                if (line.Equals("")) {
                    Console.WriteLine("got headers");
                    return;
                }

                int separator = line.IndexOf(':');
                if (separator == -1) {
                    throw new Exception("invalid http header line: " + line);
                }
                String name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' ')) {
                    pos++; // strip any spaces
                }

                string value = line.Substring(pos, line.Length - pos);
                Console.WriteLine("header: {0}:{1}", name, value);
                httpHeaders[name] = value;
            }
        }

        public void handleGETRequest()
        {
            srv.handleGETRequest(this);
        }

        private const int BUF_SIZE = 4096;
        public void handlePOSTRequest()
        {
            

            Console.WriteLine("get post data start");
            int content_len = 0;
            MemoryStream ms = new MemoryStream();
            if (this.httpHeaders.ContainsKey("Content-Length")) {
                content_len = Convert.ToInt32(this.httpHeaders["Content-Length"]);
                if (content_len > MAX_POST_SIZE) {
                    throw new Exception(
                        String.Format("POST Content-Length({0}) too big for this simple server",
                          content_len));
                }
                byte[] buf = new byte[BUF_SIZE];
                int to_read = content_len;
                while (to_read > 0) {
                    Console.WriteLine("starting Read, to_read={0}", to_read);

                    int numread = this.inputStream.Read(buf, 0, Math.Min(BUF_SIZE, to_read));
                    Console.WriteLine("read finished, numread={0}", numread);
                    if (numread == 0) {
                        if (to_read == 0) {
                            break;
                        }
                        else {
                            throw new Exception("client disconnected during post");
                        }
                    }
                    to_read -= numread;
                    ms.Write(buf, 0, numread);
                }
                ms.Seek(0, SeekOrigin.Begin);
            }
            Console.WriteLine("get post data end");
            srv.handlePOSTRequest(this, new StreamReader(ms));

        }

        public void writeSuccess(string content_type = "text/html")
        {
            outputStream.WriteLine("HTTP/1.0 200 OK");
            outputStream.WriteLine("Content-Type: " + content_type);
            outputStream.WriteLine("Connection: close");
            outputStream.WriteLine("");
        }

        public void writeFailure()
        {
            outputStream.WriteLine("HTTP/1.0 404 File not found");
            outputStream.WriteLine("Connection: close");
            outputStream.WriteLine("");
        }

        public void writeLine(String line)
        {
            outputStream.WriteLine(line);
        }
    }

    public abstract class HttpServer
    {

        protected int port;
        TcpListener listener;
        bool is_active = true;

        public HttpServer(int port)
        {
            this.port = port;
        }

        public void listen()
        {
            listener = new TcpListener(port);
            listener.Start();
            while (is_active) {
                TcpClient s = listener.AcceptTcpClient();
                HttpProcessor processor = new HttpProcessor(s, this);
                Thread thread = new Thread(new ThreadStart(processor.process));
                thread.Start();
                Thread.Sleep(1);
            }
            Console.WriteLine("Server stopped.");
        }

        public void stop()
        {
            Console.WriteLine("Killing server...");
            is_active = false;
        }

        public abstract void handleGETRequest(HttpProcessor p);
        public abstract void handlePOSTRequest(HttpProcessor p, StreamReader inputData);
    }
}
