using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents wardrobe xml factory
    /// </summary>
    public class WardrobeXmlFactory : FurnitureBaseXmlFactory, IXmlDomainFactory<Wardrobe>
    {
        /// <summary>
        /// Intializes new wardrobe xml factory
        /// </summary>
        /// <param name="abstractMaterialXmlFactory">Specified abstract materials xml factory</param>
        public WardrobeXmlFactory(IAbstractMaterialXmlFactory<Material> abstractMaterialXmlFactory) :
                                  base(abstractMaterialXmlFactory)
        {
        }
        /// <summary>
        /// Creates wardrobe from xml node
        /// </summary>
        public Wardrobe Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description, purpose, material) = GetFurnitureParameters(nodes);
            return new Wardrobe(weight, value, description, material, purpose);
        }
    }
}