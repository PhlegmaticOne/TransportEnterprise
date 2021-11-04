using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class PetrolA95XmlFactory : ChemistryBaseXmlFactory, IXmlDomainFactory<PetrolA95>
    {
        public PetrolA95 Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description, dangers) = GetChemistryParameters(nodes);
            return new PetrolA95(weight, value, dangers, description);
        }
    }
}
