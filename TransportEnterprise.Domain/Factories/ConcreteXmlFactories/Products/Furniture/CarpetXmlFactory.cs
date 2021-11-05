using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents carpet xml factory
    /// </summary>
    public class CarpetXmlFactory : FurnitureBaseXmlFactory, IXmlDomainFactory<Carpet>
    {
        /// <summary>
        /// Intializes new carpet xml factory
        /// </summary>
        /// <param name="abstractMaterialXmlFactory">Specified abstract materials xml factory</param>
        public CarpetXmlFactory(IAbstractMaterialXmlFactory<Material> abstractMaterialXmlFactory) :
                                base(abstractMaterialXmlFactory)
        {
        }
        /// <summary>
        /// Creates carpet from xml node
        /// </summary>
        public Carpet Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description, purpose, material) = GetFurnitureParameters(nodes);
            return new Carpet(weight, value, description, material, purpose);
        }
    }
}
