using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents petrol A92 xml factory
    /// </summary>
    public class PetrolA92XmlFactory : ChemistryBaseXmlFactory, IXmlDomainFactory<PetrolA92>
    {
        /// <summary>
        /// Creates petrol A92 from xml node
        /// </summary>
        public PetrolA92 Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description, dangers) = GetChemistryParameters(nodes);
            return new PetrolA92(weight, value, dangers, description);
        }
    }
}
