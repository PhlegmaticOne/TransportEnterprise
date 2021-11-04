using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class CarbonXmlFactory : ChemistryBaseXmlFactory, IXmlDomainFactory<Carbon>
    {
        public Carbon Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description, dangers) = GetChemistryParameters(nodes);
            return new Carbon(weight, value, dangers, description);
        }
    }
}
