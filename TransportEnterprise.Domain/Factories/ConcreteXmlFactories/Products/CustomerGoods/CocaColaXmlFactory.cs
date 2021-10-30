using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class CocaColaXmlFactory : IDomainFactory<CocaCola>
    {
        private readonly ICollection<XmlNode> _nodes;
        public CocaColaXmlFactory(XmlNode node) => _nodes = node.ChildNodes.ToList();
        public CocaCola Create()
        {
            var weight = decimal.Parse(_nodes.GetInnerText("Weight"));
            var description = _nodes.GetInnerText("Description");
            var cocaColaTaste = _nodes.GetNode("ColaTaste").ToCocaColaTaste();
            return new CocaCola(weight, description, cocaColaTaste);
        }
    }
}
