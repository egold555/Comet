﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security;
using System.Windows.Forms;
using System.Xml;

using Properties;

namespace VixenPlus {
    public class Group {
        public static string AllChannels = Resources.AllChannels;
        public static string ManageGroups = "Manage Groups";
        public const string GroupTextDivider = "~";

        private readonly List<Channel> _currentList = new List<Channel>();

        internal static Dictionary<string, GroupData> LoadGroups(string groupFile) {
            Dictionary<string, GroupData> groups = null;
            try {
                var doc = Xml.LoadDocument(groupFile).DocumentElement;
                if (doc != null && doc.ParentNode != null) {
                    XmlNode nodes = doc.ParentNode["Groups"];
                    if (nodes != null) {
                        groups = new Dictionary<string, GroupData>();
                        foreach (XmlNode node in nodes) {
                            if (node == null || node.Attributes == null) {
                                continue;
                            }
                            var name = node.Attributes["Name"] == null ? null : node.Attributes["Name"].Value;
                            if (name == null) {
                                throw new XmlSyntaxException(String.Format(Resources.MissingNameAttribute, Path.GetFileName(groupFile), node));
                            }
                            //var contains = node.Attributes["Contains"] == null ? null : node.Attributes["Contains"].Value;
                            //if (String.IsNullOrEmpty(contains)) contains = null;
                            var color = node.Attributes["Color"] == null ? Color.White : Color.FromArgb(Int32.Parse(node.Attributes["Color"].Value));
                            var zoom = node.Attributes["Zoom"] == null ? "100%" : node.Attributes["Zoom"].Value;
                            var text = String.Empty;
                            foreach (XmlNode child in node.ChildNodes) {
                                if (child.InnerText == "") {
                                    continue;
                                }
                                switch (child.Name) {
                                    case "Channels":
                                        text += child.InnerText + ",";
                                        break;
                                    case "Contains":
                                        foreach (var group in child.InnerText.Split(new[] {','})) {
                                            text += GroupTextDivider + @group + ",";
                                        }
                                        break;      
                                }
                            }
                            groups.Add(name, new GroupData {Name = name, GroupColor = color, GroupChannels = text.TrimEnd(new[] {','}), Zoom = zoom});
                        }
                    }
                }
            }
            catch (Exception) {
                var msg = String.Format(Resources.ErrorLoadingGroup, Path.GetFileName(groupFile), Vendor.ProductName);
                if (MessageBox.Show(msg, Resources.GroupLoadingError, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) {
                    throw;
                }
            }
            return groups;
        }


        internal List<Channel> GetGroupChannels(string nodeData, Dictionary<string, GroupData> groups, List<Channel> fullChannelList) {
            try {
                var groupChannels = groups[nodeData].GroupChannels;
                foreach (var node in groupChannels.Split(new[] {','})) {
                    if (node.StartsWith(GroupTextDivider)) {
                        GetGroupChannels(node.TrimStart(GroupTextDivider.ToCharArray()), groups, fullChannelList);
                    }
                    else {
                        int channel;
                        if (Int32.TryParse(node, out channel) && !_currentList.Contains(fullChannelList[channel])) {
                            _currentList.Add(fullChannelList[channel]);
                        }
                    }
                }
            }
            catch (KeyNotFoundException) {
                // we just build the group anyhow since it may have channels missing because of an improper formatted group file.
            }
            return _currentList;
        }
    }
}
