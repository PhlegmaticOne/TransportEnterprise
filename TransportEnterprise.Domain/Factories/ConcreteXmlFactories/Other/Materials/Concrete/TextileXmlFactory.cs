using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents textile xml factory
    /// </summary>
    public class TextileXmlFactory : MaterialBaseXmlFactory, IMaterialXmlFactory<Textile>
    {
        /// <summary>
        /// Creates textile from xml node
        /// </summary>
        public Textile CreateMaterial(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (price, color) = GetMaterialParameters(nodes);
            var textileType = nodes.GetNode("TextileType").ToTextileType();
            return new Textile(price, color, textileType);
        }
    }
}
