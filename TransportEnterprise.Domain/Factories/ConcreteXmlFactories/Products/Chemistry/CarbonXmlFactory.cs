using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents carbon xml factory
    /// </summary>
    public class CarbonXmlFactory : ChemistryBaseXmlFactory, IXmlDomainFactory<Carbon>
    {
        /// <summary>
        /// Creates carbon from xml node
        /// </summary>
        public Carbon Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description, dangers) = GetChemistryParameters(nodes);
            return new Carbon(weight, value, dangers, description);
        }
    }
}
