using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents products base xml factory
    /// </summary>
    public class ProductsBaseXmlFactory
    {
        /// <summary>
        /// Gets properties values of product base type from xml node
        /// </summary>
        protected static (decimal, decimal, string) GetProductParameters(ICollection<XmlNode> nodes) =>
            (decimal.Parse(nodes.GetInnerText("Weight")),
             decimal.Parse(nodes.GetInnerText("Value")),
             nodes.GetInnerText("Description"));
    }
}
