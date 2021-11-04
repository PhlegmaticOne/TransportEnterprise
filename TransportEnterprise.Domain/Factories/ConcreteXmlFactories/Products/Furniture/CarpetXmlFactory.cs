using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class CarpetXmlFactory : FurnitureBaseXmlFactory, IXmlDomainFactory<Carpet>
    {
        public CarpetXmlFactory(IAbstractMaterialXmlFactory<Material> abstractMaterialXmlFactory) :
                                base(abstractMaterialXmlFactory)
        {
        }
        public Carpet Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description, purpose, material) = GetFurnitureParameters(nodes);
            return new Carpet(weight, value, description, material, purpose);
        }
    }
}
