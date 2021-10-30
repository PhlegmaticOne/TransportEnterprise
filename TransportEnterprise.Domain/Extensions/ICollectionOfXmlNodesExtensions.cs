using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace TransportEnterprise.Models.Extensions
{
    public static class ICollectionOfXmlNodesExtensions
    {
        public static string GetInnerText(this ICollection<XmlNode> xmlNodes, string nodeName) => xmlNodes.GetNode(nodeName).InnerText;
        public static XmlNode GetNode(this ICollection<XmlNode> xmlNodes, string nodeName) =>
            xmlNodes.First(n => n.OuterXml.Contains(nodeName, StringComparison.InvariantCultureIgnoreCase));
    }
}
