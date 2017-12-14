using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
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
    public class Renard : RenardBase, IEventDrivenOutputPlugIn {
        private bool _isValidPort;
        private SetupDialog _dialog;
        private SerialPort _serialPort;
        private SetupData _setupData;
        private XmlNode _setupNode;

        private const string PortNode = "name";
        private const string BaudNode = "baud";
        private const string ParityNode = "partity";
        private const string DataNode = "data";
        private const string StopNode = "stop";
        private const string HoldNode = "HoldPort";

        protected override bool Open()
        {
            _isValidPort = SerialPort.GetPortNames().Contains(_serialPort.PortName);
            if (_isValidPort) {
                if (!_serialPort.IsOpen) {
                    _serialPort.Open();
                }
                _serialPort.Handshake = Handshake.None;
                _serialPort.Encoding = Encoding.UTF8;
                _serialPort.RtsEnable = true;
                _serialPort.DtrEnable = true;

                return true;
            }
            else {
                MessageBox.Show(String.Format("{0} does not exist for {1}", _serialPort.PortName, Name));
                return false;
            }
        }

        protected override void Close()
        {
            if (_serialPort.IsOpen) {
                _serialPort.Close();
            }
        }

        protected override void SendPacket(List<byte> bytes)
        {
            try {
                _serialPort.Write(bytes.ToArray(), 0, bytes.Count);
            }
            catch (InvalidOperationException) {
                if (SerialPort.GetPortNames().Contains(_setupData.GetString(_setupNode, PortNode, "COM1"))) {
                    "Reconnecting...".CrashLog();
                    try {
                        InitSerialPort();
                        _serialPort.Open();
                        "Success!".CrashLog();
                    }
                    catch (Exception e) {
                        ("Failed! " + e.Message).CrashLog();
                    }
                }
            }
            catch (IOException ioe) {
                ("IO Exception: " + ioe.Message).CrashLog();
            }
        }

        public void Initialize(IExecutable executableObject, SetupData setupData, XmlNode setupNode) {
            _setupData = setupData;
            _setupNode = setupNode;
            InitSerialPort();
        }


        private void InitSerialPort() {
            _serialPort = new SerialPort(_setupData.GetString(_setupNode, PortNode, "COM1"), _setupData.GetInteger(_setupNode, BaudNode, 19200),
                (Parity) Enum.Parse(typeof (Parity), _setupData.GetString(_setupNode, ParityNode, Parity.None.ToString())),
                _setupData.GetInteger(_setupNode, DataNode, 8),
                (StopBits) Enum.Parse(typeof (StopBits), _setupData.GetString(_setupNode, StopNode, StopBits.One.ToString()))) {WriteTimeout = 500};
        }




        public Control Setup() {
            return _dialog ?? (_dialog = new SetupDialog {SelectedPort = _serialPort});
        }


        public void GetSetup() {
            if (null != _dialog) {
                _serialPort = _dialog.SelectedPort;
            }

            while (_setupNode.ChildNodes.Count > 0) {
                _setupNode.RemoveChild(_setupNode.ChildNodes[0]);
            }

            AppendChild(PortNode, _serialPort.PortName);
            AppendChild(BaudNode, _serialPort.BaudRate.ToString(CultureInfo.InvariantCulture));
            AppendChild(ParityNode, _serialPort.Parity.ToString());
            AppendChild(DataNode, _serialPort.DataBits.ToString(CultureInfo.InvariantCulture));
            AppendChild(StopNode, _serialPort.StopBits.ToString());
            AppendChild(HoldNode, "True");
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
                int port;
                return int.TryParse(_serialPort.PortName.Substring(3), out port) 
                    ? String.Format("Serial: {0}, {1}, {2}, {3}, {4}",
                        _serialPort.PortName, 
                        _serialPort.BaudRate, 
                        _serialPort.DataBits,
                        _serialPort.Parity,
                        _serialPort.StopBits) 
                    : null;
            }
        }

        public string Name {
            get { return "Renard Dimmer (modified)"; }
        }
    }
}
