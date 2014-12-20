﻿using System.Globalization;
using System.Linq;
using System.Xml;

using VixenPlus;
using VixenPlus.Annotations;

namespace SeqIOHelpers {
    [UsedImplicitly]
    public class Vixen25SeqIO : SeqIOBase {

        public override string DialogFilterList() {
            return string.Format("Vixen 2.5 Sequence (*{0})|*{0}", FileExtension());
        }

        public override int PreferredOrder() {
            return 2;
        }

        public override bool CanSave() {
            return true;
        }


        public override void Save(EventSequence eventSequence) {
            var contextNode = Xml.CreateXmlDocument();
            BaseSave(contextNode, eventSequence, FormatChannel);
            contextNode.Save(eventSequence.FileName);
        }


        private static XmlNode FormatChannel(XmlDocument doc, Channel ch) {
            XmlNode node = doc.CreateElement("Channel");
            Xml.SetAttribute(node, "name", ch.Name);
            Xml.SetAttribute(node, "color", ch.Color.ToArgb().ToString(CultureInfo.InvariantCulture));
            Xml.SetAttribute(node, "output", (ch.OutputChannel - 1).ToString(CultureInfo.InvariantCulture));
            Xml.SetAttribute(node, "id", ch.Id.ToString(CultureInfo.InvariantCulture));
            Xml.SetAttribute(node, "enabled", ch.Enabled.ToString());

            if (ch.DimmingCurve != null) {
                Xml.SetValue(node, "Curve", string.Join(",", ch.DimmingCurve.Select(num => num.ToString(CultureInfo.InvariantCulture)).ToArray()));
            }

            return node;
        }


        public override bool CanOpen() {
            return true;
        }
    }
}