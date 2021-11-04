using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace TransportEnterprise.Models.Extensions
{
    /// <summary>
    /// Extensions of ICollection of XmlNode
    /// </summary>
    public static class ICollectionOfXmlNodesExtensions
    {
        /// <summary>
        /// Gets inner text of xml node
        /// </summary>
        /// <param name="xmlNodes">Collection with nodes where node with text is to find</param>
        /// <param name="nodeName">Name of node</param>
        public static string GetInnerText(this ICollection<XmlNode> xmlNodes, string nodeName) =>
            xmlNodes.GetNode(nodeName).InnerText;
        /// <summary>
        /// Gets node from the collection of nodes by its name
        /// </summary>
        public static XmlNode GetNode(this ICollection<XmlNode> xmlNodes, string nodeName) =>
            xmlNodes.First(n => n.OuterXml.Contains(nodeName, StringComparison.InvariantCultureIgnoreCase));
    }
}
