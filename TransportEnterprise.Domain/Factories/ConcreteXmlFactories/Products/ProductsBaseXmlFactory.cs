using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class ProductsBaseXmlFactory
    {
        protected static (decimal, decimal, string) GetProductParameters(ICollection<XmlNode> nodes) =>
            (decimal.Parse(nodes.GetInnerText("Weight")),
             decimal.Parse(nodes.GetInnerText("Value")),
             nodes.GetInnerText("Description"));
    }
}
