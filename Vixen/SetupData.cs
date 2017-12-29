using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace VixenPlus {
    public class SetupData : DataExtension {
        public enum PluginType {
            Output
        }

        public SetupData() : base("PlugInData") {}


        public XmlNode CreatePlugInData(IHardwarePlugin plugIn) {
            var node = Xml.SetNewValue(RootNode, "PlugIn", string.Empty);
            Xml.SetAttribute(node, "name", plugIn.Name);
            Xml.SetAttribute(node, "key", plugIn.Name.GetHashCode().ToString(CultureInfo.InvariantCulture));
            Xml.SetAttribute(node, "id", (GetAllPluginData().Count - 1).ToString(CultureInfo.InvariantCulture));
            Xml.SetAttribute(node, "enabled", bool.TrueString);
            Xml.SetAttribute(node, "type", PluginType.Output.ToString());
            return node;
        }


        public XmlNodeList GetAllPluginData() {
            return RootNode.SelectNodes("PlugIn");
        }


        public List<XmlNode> GetAllPluginData(PluginType type) {
            IEnumerable<XmlNode> nodes = RootNode.SelectNodes(string.Format("PlugIn[@type='{0}']", type)).Cast<XmlNode>();
            if (type == PluginType.Output) {
                nodes = nodes.Concat(RootNode.SelectNodes("PlugIn[not(@type)]").Cast<XmlNode>());
            }
            return nodes.ToList();
        }


        public List<XmlNode> GetAllPluginData(PluginType type, bool enabledOnly) {
            IEnumerable<XmlNode> nodes = RootNode.SelectNodes(string.Format("PlugIn[@enabled='{0}' and @type='{1}']", enabledOnly, type)).Cast<XmlNode>();
            if (type == PluginType.Output) {
                nodes = nodes.Concat(RootNode.SelectNodes(string.Format("PlugIn[not(@type) and enabled='{0}']", enabledOnly)).Cast<XmlNode>());
            }

            return nodes.ToList();
        }


        public XmlNode GetPlugInData(string pluginId) {
            return RootNode.SelectSingleNode(string.Format("PlugIn[@id='{0}']", pluginId));
        }


        public void RemovePlugInData(string pluginId) {
            RootNode.RemoveChild(GetPlugInData(pluginId));
            var num = 0;
            foreach (var node in GetAllPluginData().Cast<XmlNode>().Where(node => node.Attributes != null)) {
// ReSharper disable PossibleNullReferenceException
                node.Attributes["id"].Value = num.ToString(CultureInfo.InvariantCulture);
// ReSharper restore PossibleNullReferenceException
                num++;
            }
        }


        public void ReplaceRoot(XmlNode newBranch) {
            var parentNode = RootNode.ParentNode;
            if (parentNode != null) {
                parentNode.RemoveChild(RootNode);
            }
            var newChild = Document.ImportNode(newBranch, true);
            if (parentNode != null) {
                parentNode.AppendChild(newChild);
            }
            RootNode = newChild;
        }
    }
}