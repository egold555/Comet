﻿namespace Vixen
{
    using System;
    using System.Reflection;
    using System.Xml;

    public class SequenceExtensions : DataExtension
    {
        public SequenceExtensions() : base("Extensions")
        {
        }

        public XmlNode this[string extensionKey]
        {
            get
            {
                XmlNode node = base.m_rootNode.SelectSingleNode(string.Format("Extension[@type = \"{0}\"]", extensionKey));
                if (node == null)
                {
                    node = Xml.SetAttribute(base.m_rootNode, "Extension", "type", extensionKey);
                }
                return node;
            }
        }
    }
}

