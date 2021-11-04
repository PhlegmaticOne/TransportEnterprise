using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class PetrolA92XmlFactory : ChemistryBaseXmlFactory, IXmlDomainFactory<PetrolA92>
    {
        public PetrolA92 Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description, dangers) = GetChemistryParameters(nodes);
            return new PetrolA92(weight, value, dangers, description);
        }
    }
}
