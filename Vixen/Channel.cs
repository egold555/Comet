﻿using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

using CommonUtils;

namespace VixenPlus {
    public class Channel : IDisposable, IComparable<Channel> {
        private Color _color;


        public Channel(XmlNode channelNode) {
            OutputChannel = 0;
            Enabled = true;
            DimmingCurve = null;
            if (channelNode.Attributes == null) {
                return;
            }

            CanDoDimming = (channelNode.Attributes["name"] != null);
            // ReSharper disable PossibleNullReferenceException
            Name = CanDoDimming ? channelNode.Attributes["name"].Value : channelNode.InnerText;
            // ReSharper restore PossibleNullReferenceException

            var elementName = "color";
            try {
                Color = Color.FromArgb(Convert.ToInt32(channelNode.Attributes[elementName].Value));
                elementName = "output";
                OutputChannel = Convert.ToInt32(channelNode.Attributes[elementName].Value);
                elementName = "id";
                Id = ulong.Parse(channelNode.Attributes[elementName].Value);
                elementName = "enabled";
                Enabled = bool.Parse(channelNode.Attributes[elementName].Value);
            }
            catch (NullReferenceException) {
                MessageBox.Show(String.Format("Embedded or attached profile is missing '{0}' elenment on channel node.\n\nExiting {1}", elementName, Vendor.ProductName), "Missing element");
                throw new NullReferenceException(String.Format("Channel XML is missing '{0}' element", elementName));
            }
            
            
            if (channelNode["Curve"] == null) {
                return;
            }

            DimmingCurve = new byte[256];
            var strArray = channelNode["Curve"].InnerText.Split(new[] {','});
            var num = Math.Min(strArray.Length, 256);
            for (var i = 0; i < num; i++) {
                byte num2;
                if (byte.TryParse(strArray[i], out num2)) {
                    DimmingCurve[i] = num2;
                }
                else {
                    DimmingCurve[i] = (byte) i;
                }
            }
        }


        public Channel(string name, int outputChannel) {
            Name = name;
            OutputChannel = outputChannel;

            Enabled = true;
            DimmingCurve = null;
            Color = Color.FromArgb(-1);
            Id = Host.GetUniqueKey();
        }


        public Channel(string name, Color color, int outputChannel) : this(name, outputChannel) {
            Color = color;
        }


        public Channel(string name, int outputChannel, bool ensureUniqueId) : this(name, outputChannel) {
            if (ensureUniqueId) {
                var ticks = DateTime.Now.Ticks;
                // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
                while (ticks == DateTime.Now.Ticks) {}
            }
            Id = Host.GetUniqueKey();
        }

        public Color Color {
            get { return _color; }
            set {
                if (_color.ToArgb() == value.ToArgb()) {
                    return;
                }

                _color = value;
            }
        }

        public byte[] DimmingCurve { get; set; }

        public bool Enabled { get; set; }

        public ulong Id { get; private set; }

        public bool CanDoDimming { get; private set; }

        public string Name { get; set; }

        public int OutputChannel { get; set; }

        public int CompareTo(Channel other) {
            return Id.CompareTo(other.Id);
        }


        public void Dispose() {
            GC.SuppressFinalize(this);
        }


        public Channel Clone() {
            var channel = (Channel) MemberwiseClone();
            if (DimmingCurve == null) {
                return channel;
            }
            channel.DimmingCurve = new byte[DimmingCurve.Length];
            DimmingCurve.CopyTo(channel.DimmingCurve, 0);
            return channel;
        }


        ~Channel() {
            Dispose();
        }


        public XmlNode SaveToXml(XmlDocument doc) {
            XmlNode node = doc.CreateElement("Channel");
            if (CanDoDimming) {
                Xml.SetAttribute(node, "name", Name);
            }
            else {
                node.InnerText = Name;
            }
            Xml.SetAttribute(node, "color", Color.ToArgb().ToString(CultureInfo.InvariantCulture));
            Xml.SetAttribute(node, "output", OutputChannel.ToString(CultureInfo.InvariantCulture));
            Xml.SetAttribute(node, "id", Id.ToString(CultureInfo.InvariantCulture));
            Xml.SetAttribute(node, "enabled", Enabled.ToString());
            if (DimmingCurve != null) {
                Xml.SetValue(node, "Curve", string.Join(",", DimmingCurve.Select(num => num.ToString(CultureInfo.InvariantCulture)).ToArray()));
            }
            return node;
        }


        public override string ToString() {
            return Name;
        }


        public static void DrawItem(ListBox lb, DrawItemEventArgs e, Channel channel) {
            e.DrawItem(channel.Name, channel.Color, lb, Preference2.GetInstance().GetBoolean("UseCheckmark"));
        }


        public static void DrawItem(DrawItemEventArgs e, Channel c, bool useCheckmark = false) {
            e.DrawItem(c.Name, c.Color, useCheckmark);
        }
    }
}