﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace VixenPlus
{
	public class Xml
	{
		public static XmlNode CloneNode(XmlDocument targetDoc, XmlNode finalNode, bool deep)
		{
			var stack = new Stack<XmlNode>();
			while (finalNode != null && (finalNode is XmlElement))
			{
				stack.Push(finalNode);
				finalNode = finalNode.ParentNode;
			}
			XmlNode node = stack.Pop();
			XmlNode node2 = targetDoc.SelectSingleNode("//" + node.Name) ??
			                targetDoc.AppendChild(targetDoc.ImportNode(node, false));
			while (stack.Count > 0)
			{
				node = stack.Pop();
				XmlNode node3 = node.Attributes != null && node.Attributes["name"] != null ? node2.SelectSingleNode(node.Name + string.Format("[@name = \"{0}\"]", node.Attributes["name"].Value)) : node2.SelectSingleNode(node.Name);
				node2 = node3 ?? node2.AppendChild(stack.Count == 0 ? targetDoc.ImportNode(node, deep) : targetDoc.ImportNode(node, false));
			}
			return node2;
		}

		public static XmlDocument CreateXmlDocument()
		{
			var document = new XmlDocument();
			XmlDeclaration newChild = document.CreateXmlDeclaration("1.0", "utf-8", string.Empty);
			document.AppendChild(newChild);
			return document;
		}

		public static XmlDocument CreateXmlDocument(string rootNodeName)
		{
			var document = new XmlDocument();
			XmlDeclaration newChild = document.CreateXmlDeclaration("1.0", Encoding.UTF8.WebName, string.Empty);
			document.AppendChild(newChild);
			document.AppendChild(document.CreateElement(rootNodeName));
			return document;
		}

		public static string GetAttribute(XmlNode node, string attributeName)
		{
			if (node.Attributes != null && node.Attributes[attributeName] == null)
			{
				SetAttribute(node, attributeName, "");
				return "";
			}
			return node.Attributes[attributeName].Value;
		}

		public static string GetAttribute(XmlNode node, string attributeName, string attributeDefaultValue)
		{
			if (node.Attributes != null && node.Attributes[attributeName] == null)
			{
				SetAttribute(node, attributeName, attributeDefaultValue);
				return attributeDefaultValue;
			}
			return node.Attributes[attributeName].Value;
		}

		public static XmlNode GetEmptyNodeAlways(XmlNode contextNode, string nodeName)
		{
			XmlNode nodeAlways = GetNodeAlways(contextNode, nodeName);
			nodeAlways.RemoveAll();
			return nodeAlways;
		}

		public static XmlNode GetNodeAlways(XmlNode contextNode, string nodeName)
		{
			XmlNode newChild = contextNode.SelectSingleNode(nodeName);
			if (newChild == null)
			{
				newChild =
					(contextNode.OwnerDocument ?? ((XmlDocument) contextNode)).CreateElement(
						nodeName);
				contextNode.AppendChild(newChild);
			}
			return newChild;
		}

		public static XmlNode GetNodeAlways(XmlNode contextNode, string nodeName, string defaultValue)
		{
			XmlNode newChild = contextNode.SelectSingleNode(nodeName);
			if (newChild == null)
			{
				newChild =
					(contextNode.OwnerDocument ?? ((XmlDocument) contextNode)).CreateElement(
						nodeName);
				contextNode.AppendChild(newChild);
				newChild.InnerText = defaultValue;
			}
			return newChild;
		}

		public static string GetOptionalNodeValue(XmlNode contextNode, string nodeName)
		{
			XmlNode node = contextNode.SelectSingleNode(nodeName);
			if (node == null)
			{
				return string.Empty;
			}
			return node.InnerText;
		}

		public static XmlNode GetRequiredNode(XmlNode contextNode, string nodeName)
		{
			XmlNode node = contextNode.SelectSingleNode(nodeName);
			if (node == null)
			{
				throw new Exception(string.Format("Required value \"{0}\" was not found in context node \"{1}\".", nodeName,
				                                  contextNode.Name));
			}
			return node;
		}

		public static XmlDocument LoadDocument(string filename)
		{
			var document = new XmlDocument();
			document.Load(filename);
			return document;
		}

		public static XmlNode SetAttribute(XmlNode node, string attributeName, string attributeValue)
		{
			if (node.Attributes != null)
			{
				XmlAttribute attribute = node.Attributes[attributeName];
				if (attribute == null)
				{
					attribute = (node.OwnerDocument ?? ((XmlDocument) node)).CreateAttribute(attributeName);
					node.Attributes.Append(attribute);
				}
				attribute.Value = attributeValue;
			}
			return node;
		}

		public static XmlNode SetAttribute(XmlNode contextNode, string nodeName, string attributeName, string attributeValue)
		{
			XmlNode newChild = contextNode.SelectSingleNode(nodeName);
			XmlDocument document = contextNode.OwnerDocument ?? ((XmlDocument) contextNode);
			if (newChild == null)
			{
				newChild = document.CreateElement(nodeName);
				contextNode.AppendChild(newChild);
			}
			if (newChild.Attributes != null)
			{
				XmlAttribute node = newChild.Attributes[attributeName];
				if (node == null)
				{
					node = document.CreateAttribute(attributeName);
					newChild.Attributes.Append(node);
				}
				node.Value = attributeValue;
			}
			return newChild;
		}

		public static XmlNode SetNewValue(XmlNode contextNode, string nodeName, string nodeValue)
		{
			XmlNode newChild =
				(contextNode.OwnerDocument ?? ((XmlDocument) contextNode)).CreateElement(
					nodeName);
			contextNode.AppendChild(newChild);
			newChild.InnerText = nodeValue;
			return newChild;
		}

		public static XmlNode SetValue(XmlNode contextNode, string nodeName, string nodeValue)
		{
			XmlNode newChild = contextNode.SelectSingleNode(nodeName);
			if (newChild == null)
			{
				newChild =
					(contextNode.OwnerDocument ?? ((XmlDocument) contextNode)).CreateElement(
						nodeName);
				contextNode.AppendChild(newChild);
			}
			newChild.InnerText = nodeValue;
			return newChild;
		}
	}
}