using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class WardrobeXmlFactory : FurnitureBaseXmlFactory, IXmlDomainFactory<Wardrobe>
    {
        public WardrobeXmlFactory(IAbstractMaterialXmlFactory<Material> abstractMaterialXmlFactory) :
                                  base(abstractMaterialXmlFactory)
        {
        }
        public Wardrobe Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description, purpose, material) = GetFurnitureParameters(nodes);
            return new Wardrobe(weight, value, description, material, purpose);
        }
    }
}
