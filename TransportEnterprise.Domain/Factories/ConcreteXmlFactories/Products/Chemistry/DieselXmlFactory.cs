using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class DieselXmlFactory : ChemistryBaseXmlFactory, IXmlDomainFactory<Diesel>
    {
        public Diesel Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description, dangers) = GetChemistryParameters(nodes);
            return new Diesel(weight, value, dangers, description);
        }
    }
}
