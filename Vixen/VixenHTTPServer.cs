using System;
using System.Collections;
using System.IO;
using System.Linq;
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
        string[] sequences = Directory.GetFiles(VixenPlusCommon.Paths.SequencePath, "*.vix", SearchOption.AllDirectories);
        IExecution _executionInterface = null;
        int _executionContextHandle = -1;
        EventSequence sequence = null;
        private byte[] _channelLevels = null;

        public VixenHTTPServerHandler(int port) : base(port)
        { }

        public override void handleGETRequest(HttpProcessor p)
        {

            string[] args = p.http_url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            p.writeSuccess();

            if (args == null || args.Length == 0) {
                showHelp(p);
                return;
            }

            if (args[0] == "sequence") {
                string fullPath = Path.Combine(VixenPlusCommon.Paths.SequencePath, Uri.UnescapeDataString(args[1]));
                object obj2;
                if (sequences.Contains(fullPath)) {
                    //Sequence exists
                    if (Interfaces.Available.TryGetValue("IExecution", out obj2)) {

                        var fileIOHandler = FileIOHelper.GetByExtension(fullPath);
                        sequence = fileIOHandler.OpenSequence(fullPath);

                        _executionInterface = (IExecution)obj2;
                        _executionContextHandle = _executionInterface.RequestContext(false, true, null);
                        _executionInterface.SetAsynchronousContext(_executionContextHandle, sequence);

                        try {

                            if (_channelLevels == null) { _channelLevels = new byte[sequence.FullChannelCount]; }


                            if (args.Length == 2) {
                                p.writeLine("Successfully selected sequence!");
                                p.writeLine("<br>");
                                p.writeLine("Commands: <br>");
                                p.writeLine("   /play/ <br>");
                                p.writeLine("   /play/ms/ <br>");
                                p.writeLine("   /pause/ <br>");
                                p.writeLine("   /stop/ <br>");
                                p.writeLine("   /channels/ <br>");
                                return;
                            }

                            if (args[2] == "channels") {
                                int maxChannels = sequence.FullChannelCount;
                                if (args.Length == 3) {
                                    p.writeLine("/set/channelnum/0-255");
                                    p.writeLine("<br>");
                                    p.writeLine("/get/channelnum/");
                                    p.writeLine("<br>");
                                    p.writeLine("Max channels: " + maxChannels);
                                    return;
                                }

                                if (args[3] == "set") {
                                    int channel = int.Parse(args[4]);
                                    byte value = byte.Parse(args[5]);
                                    _channelLevels[channel] = value;
                                    updateChannels();
                                    p.writeLine("Executed command: " + args[2]);
                                }

                                if (args[3] == "get") {
                                    int channel = int.Parse(args[4]);
                                    p.writeLine("" + _channelLevels[channel]);
                                }
                            }
                        } finally {
                            _executionInterface.ReleaseContext(_executionContextHandle);
                        }
                       
                    }
                }
                else {
                    //Error and say that their sequence they selected doesnt exist.
                    p.writeLine(args[1] + " Does not exist.");
                    p.writeLine("<br>");
                    p.writeLine("Selectable sequences: ");
                    p.writeLine("<br>");
                    printoutVixenSequences(p);
                }
            }
            else {
                showHelp(p);
            }



        }

        private void updateChannels()
        {
            _executionInterface.SetChannelStates(_executionContextHandle, _channelLevels);
        }

        private void showHelp(HttpProcessor p)
        {
            p.writeLine("<h1>Info:</h1>");
            p.writeLine("<br>");
            p.writeLine("<h2>Selectable sequences:</h2>");
            p.writeLine("<br>");
            printoutVixenSequences(p);
        }

        private void printoutVixenSequences(HttpProcessor p)
        {

            foreach (String s in sequences) {
                p.writeLine(s);
                p.writeLine("<br>");
            }
        }

        public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
        {
        }

        /*
         * /sequence/sequence_name/
         * 
         */
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
                writeFailure(e);
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

        private void writeFailure(Exception e)
        {
            outputStream.WriteLine("HTTP/1.0 500 Internal error");
            outputStream.WriteLine("<br>");
            outputStream.WriteLine(e.ToString());
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
