using System.Collections.Generic;
using System.Xml;

namespace TransportEnterprise.Models.Extensions
{
    /// <summary>
    /// Extensions for XmlNodeList
    /// </summary>
    public static class XmlNodeListExtensions
    {
        /// <summary>
        /// Converts XmlNodeList to collection of XmlNode
        /// </summary>
        public static ICollection<XmlNode> ToList(this XmlNodeList xmlNodeList)
        {
            var list = new List<XmlNode>();
            foreach (XmlNode item in xmlNodeList)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
