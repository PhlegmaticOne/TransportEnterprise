using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class CocaColaXmlFactory : ProductsBaseXmlFactory, IXmlDomainFactory<CocaCola>
    {
        public CocaCola Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description) = GetProductParameters(nodes);
            var cocaColaTaste = nodes.GetNode("ColaTaste").ToCocaColaTaste();
            return new CocaCola(weight, value, description, cocaColaTaste);
        }
    }
}
