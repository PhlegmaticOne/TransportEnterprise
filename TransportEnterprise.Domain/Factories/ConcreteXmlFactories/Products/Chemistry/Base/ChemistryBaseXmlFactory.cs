using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents chemistry base xml factory
    /// </summary>
    public class ChemistryBaseXmlFactory : ProductsBaseXmlFactory
    {
        /// <summary>
        /// Gets properties values of chemistry base type from xml node
        /// </summary>
        protected static (decimal, decimal, string, ICollection<ChemistryDanger>)
                          GetChemistryParameters(ICollection<XmlNode> nodes)
        {
            var (weight, value, description) = GetProductParameters(nodes);
            var xmlDangers = nodes.GetNode("ChemistryDangers");
            var dangers = new List<ChemistryDanger>();
            foreach (XmlNode xmlDanger in xmlDangers)
            {
                dangers.Add(xmlDanger.ToChemistryDanger());
            }
            return (weight, value, description, dangers);
        }
    }
}
