using System.Collections.Generic;
using System.Xml;

namespace TransportEnterprise.Models.Extensions
{ 
    public static class XmlNodeListExtensions
    {
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
