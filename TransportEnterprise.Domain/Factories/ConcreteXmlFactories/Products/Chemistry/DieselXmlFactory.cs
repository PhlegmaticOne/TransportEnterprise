using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents diesel xml factory
    /// </summary>
    public class DieselXmlFactory : ChemistryBaseXmlFactory, IXmlDomainFactory<Diesel>
    {
        /// <summary>
        /// Creates diesel from xml node
        /// </summary>
        public Diesel Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description, dangers) = GetChemistryParameters(nodes);
            return new Diesel(weight, value, dangers, description);
        }
    }
}
