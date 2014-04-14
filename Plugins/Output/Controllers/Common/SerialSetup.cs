﻿using System;
using System.Globalization;
using System.IO.Ports;
//using System.Text;
using System.Text;
using System.Windows.Forms;

using Controllers.Properties;


namespace Controllers.Common {
    public partial class SerialSetup : UserControl {

        private const int BaudRateWarningLevel = 6;

        private const string DefaultComPort = "COM1";
        private const int DefaultBaudRate = 57600;
        private const int DefaultDataBits = 8;

        private readonly SerialPort _serialPort;


        public SerialSetup() {
            components = null;
            _serialPort = null;
            InitializeComponent();
        }

        public SerialSetup(SerialPort serialPort) {
            components = null;
            _serialPort = serialPort;
            InitializeComponent();
        }

        public SerialPort SelectedPort {
            get {
                return new SerialPort(cbPortName.SelectedItem.ToString(), int.Parse(cbBaudRate.SelectedItem.ToString()),
                                      (Parity)cbParity.SelectedItem, int.Parse(cbDataBits.SelectedItem.ToString()), (StopBits)cbStopBits.SelectedItem);
            }
        }


        public bool ValidateSettings() {
            var isValid = true;

            var builder = new StringBuilder();
            if (cbPortName.SelectedIndex == -1) {
                builder.AppendLine(Resources.Serial_PortError);
            }
            if (cbBaudRate.SelectedIndex == -1) {
                builder.AppendLine(Resources.Serial_BaudError);
            }
            if (cbParity.SelectedIndex == -1) {
                builder.AppendLine(Resources.Serial_ParityError);
            }
            int result;
            if (!int.TryParse(cbDataBits.SelectedItem.ToString(), out result)) {
                builder.AppendLine(Resources.Serial_DataBitsError);
            }
            if (cbStopBits.SelectedIndex == -1) {
                builder.AppendLine(Resources.Serial_StopBitsError);
            }
            if (builder.Length > 0) {
                MessageBox.Show(Resources.Serial_Resolve + builder, "Vixen+", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                isValid = false;
            }

            return isValid;
        }



        private void Init(SerialPort serialPort) {
            cbPortName.Items.AddRange(SerialPort.GetPortNames());

            cbParity.Items.Add(Parity.Even);
            cbParity.Items.Add(Parity.Mark);
            cbParity.Items.Add(Parity.None);
            cbParity.Items.Add(Parity.Odd);
            cbParity.Items.Add(Parity.Space);

            cbStopBits.Items.Add(StopBits.One);
            cbStopBits.Items.Add(StopBits.OnePointFive);
            cbStopBits.Items.Add(StopBits.Two);

            if (serialPort == null) {
                serialPort = new SerialPort(DefaultComPort, DefaultBaudRate, Parity.None, DefaultDataBits, StopBits.One);
            }

            cbPortName.SelectedIndex = cbPortName.Items.IndexOf(serialPort.PortName);
            cbBaudRate.SelectedItem = serialPort.BaudRate.ToString(CultureInfo.InvariantCulture);
            cbParity.SelectedItem = serialPort.Parity;
            cbDataBits.SelectedItem = serialPort.DataBits.ToString(CultureInfo.InvariantCulture);
            cbStopBits.SelectedItem = serialPort.StopBits;
        }

        private void comboBoxBaudRate_SelectedIndexChanged(object sender, EventArgs e) {
            // If baud rate is > BaudRateWarningLevel, warn that it may not work.
            lblWarn.Text = cbBaudRate.SelectedIndex > BaudRateWarningLevel ? Resources.HighBaudRateSupport : "";
        }

        private void SerialSetup_Load(object sender, EventArgs e) {
            if (DesignMode) return;
            Init(_serialPort);
        }
    }
}