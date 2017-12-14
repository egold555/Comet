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
    public class RenardNetwork : RenardBase, IEventDrivenOutputPlugIn {
        private TcpClient _client;
        private Stream _portStream;
        private NetworkPortSetup _dialog;
        private string _hostName;
        private int _portNumber;
        private SetupData _setupData;
        private XmlNode _setupNode;

        private const string PortNode = "port";
        private const string HostNode = "host";

        protected override bool Open()
        {
            return Open(true);
        }

        private bool Open(bool showErrorDialog)
        {
            _client = new TcpClient();
            _portStream = null;
            _client.NoDelay = true;
            try {
                _client.Connect(_hostName, _portNumber);
                _portStream = _client.GetStream();
            }
            catch (Exception e) {
                if (showErrorDialog) {
                    MessageBox.Show(String.Format("Could not open network port at '{0}:{1}'; {2}", _hostName, _portNumber, e.Message));
                }
                return false;
            }

            return true;
        }

        protected override void Close()
        {
            if (_portStream != null) {
                _portStream.Close();
                _portStream = null;
            }
            if (_client != null) {
                _client.Dispose();
                _client = null;
            }
        }

        protected override void SendPacket(List<byte> bytes)
        {
            try {
                _portStream.WriteAsync(bytes.ToArray(), 0, bytes.Count);
            }
            catch (Exception e) {
                ("IO Exception: " + e.Message).CrashLog();

                // Try to reconnect.
                Close();
                Open(false);
            }
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


    }
}
