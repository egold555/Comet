using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

using Controllers.Common;

using VixenPlus;
using VixenPlus.Annotations;

using VixenPlusCommon;

namespace Controllers.Renard {
    [UsedImplicitly]
    public class RenardNetwork : IEventDrivenOutputPlugIn {
        private byte[] _channelValues;
        private AutoResetEvent _eventTrigger;
        private TcpClient _client;
        private Stream _portStream;
        private NetworkPortSetup _dialog;
        private string _hostName;
        private int _portNumber;
        private SetupData _setupData;
        private XmlNode _setupNode;
        private RunState _state = RunState.Stopped;

        private const byte ReplacementValue = 0x7c;
        private const byte PacketIgnoreValue = 0x7d;
        private const byte StreamStartValue = 0x7e;
        private const byte PacketEndValue = 0x7f;
        private const byte PacketStartValue = 0x80;

        private const string PortNode = "port";
        private const string HostNode = "host";

        public void Event(byte[] channelValues) {
            _channelValues = channelValues;
            _eventTrigger.Set();
        }


        private void EventThread() {
            State = RunState.Running;
            _eventTrigger = new AutoResetEvent(false);
            try {
                while (State == RunState.Running) {
                    _eventTrigger.WaitOne();
                    try {
                        FireEvent();
                    }
                    catch (TimeoutException) {}
                }
            }
            catch {
                if (State == RunState.Running) {
                    State = RunState.Stopping;
                }
            }
            finally {
                State = RunState.Stopped;
            }
        }


        private void FireEvent() {
            if (State != RunState.Running) {
                return;
            }

            DoEvent(_channelValues);
        }


        public void Initialize(IExecutable executableObject, SetupData setupData, XmlNode setupNode) {
            _setupData = setupData;
            _setupNode = setupNode;
            InitPortData();
        }


        private void InitPortData() {
            _hostName = _setupData.GetString(_setupNode, HostNode, "192.168.1.0");
            _portNumber = _setupData.GetInteger(_setupNode, PortNode, 23);
        }


        private readonly List<byte> _packet = new List<byte>();


        private void DoEvent(IEnumerable<byte> channelValues) {
            if (_portStream == null) return;

            _packet.Clear();
            _packet.Add(StreamStartValue);
            _packet.Add(PacketStartValue);
            foreach (var c in channelValues) {
                switch (c) {
                    case PacketIgnoreValue:
                    case StreamStartValue:
                        _packet.Add(ReplacementValue);
                        break;
                    case PacketEndValue:
                        _packet.Add(PacketStartValue);
                        break;
                    default:
                        _packet.Add(c);
                        break;
                }
                if ((_packet.Count % 100) == 0) {
                    _packet.Add(PacketIgnoreValue);
                }
            }


            try {
                _portStream.WriteAsync(_packet.ToArray(), 0, _packet.Count);
            }
            catch (IOException ioe) {
                ("IO Exception: " + ioe.Message).CrashLog();
            }
        }


        public Control Setup() {
            return _dialog ?? (_dialog = new NetworkPortSetup {HostName = _hostName, PortNumber = _portNumber});
        }


        public void GetSetup() {
            if (null != _dialog) {
                _hostName = _dialog.HostName;
                _portNumber = _dialog.PortNumber;
            }

            while (_setupNode.ChildNodes.Count > 0) {
                _setupNode.RemoveChild(_setupNode.ChildNodes[0]);
            }

            AppendChild(HostNode, _hostName);
            AppendChild(PortNode, _portNumber.ToString(CultureInfo.InvariantCulture));
        }


        private void AppendChild(string key, string value) {
            if (_setupNode.OwnerDocument == null) {
                return;
            }

            var newChild = _setupNode.OwnerDocument.CreateElement(key);
            newChild.InnerXml = value;
            _setupNode.AppendChild(newChild);
        }


        public void CloseSetup() {
            if (_dialog == null) {
                return;
            }

            _dialog.Dispose();
            _dialog = null;
        }


        public void Shutdown() {
            if (State != RunState.Running) {
                if (_portStream != null) {
                    _portStream.Close();
                    _portStream = null;
                }
                if (_client != null) {
                    _client.Dispose();
                    _client = null;
                }
                return;
            }

            State = RunState.Stopping;
            while (State != RunState.Stopped) {
                Thread.Sleep(5);//todo replace with Task.Delay() when using 4.5
            }

            if (_portStream != null) {
                _portStream.Close();
                _portStream = null;
            }
            if (_client != null) {
                _client.Dispose();
                _client = null;
            }
        }


        public void Startup() {
            OpenNetworkPort();

            if (_portStream == null) {
                return;
            }

            new Thread(EventThread).Start();
            while (State != RunState.Running) {
                Thread.Sleep(1); //todo replace with Task.Delay() when using 4.5
            }
        }

        private void OpenNetworkPort()
        {
            _client = new TcpClient();
            _portStream = null;
            _client.NoDelay = true;
            try {
                _client.Connect(_hostName, _portNumber);
                _portStream = _client.GetStream();
            }
            catch (Exception e) {
                MessageBox.Show(String.Format("Could not open network port at '{0}:{1}'; {2}", _hostName, _portNumber, e.Message));
                return;
            }
        }

        public override string ToString() {
            return Name;
        }


        [UsedImplicitly]
        public bool SupportsLiveSetup() {
            return true;
        }


        public string HardwareMap {
            get {
                return string.Format("Network: {0}:{1}", _hostName, _portNumber);
            }
        }

        public string Name {
            get { return "Renard Network"; }
        }

        private RunState State {
            get { return _state; }
            set {
                _state = value;
                if (value != RunState.Stopping) {
                    return;
                }
                _eventTrigger.Set();
                _eventTrigger.Close();
                _eventTrigger = null;
            }
        }

        private enum RunState {
            Running,
            Stopping,
            Stopped
        }
    }
}
