using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class WoodXmlFactory : MaterialBaseXmlFactory, IMaterialXmlFactory<Wood>
    {
        public Wood CreateMaterial(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (price, color) = GetMaterialParameters(nodes);
            var woodType = nodes.GetNode("WoodType").ToWoodType();
            return new Wood(price, color, woodType);
        }
    }
}
