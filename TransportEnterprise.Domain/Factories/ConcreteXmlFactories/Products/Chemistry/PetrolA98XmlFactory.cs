using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class PetrolA98XmlFactory : ChemistryBaseXmlFactory, IXmlDomainFactory<PetrolA98>
    {
        public PetrolA98 Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description, dangers) = GetChemistryParameters(nodes);
            return new PetrolA98(weight, value, dangers, description);
        }
    }
}
