using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class ActrosMP3XmlFactory : IDomainFactory<ActrosMP3>
    {
        private readonly ICollection<XmlNode> _nodes;
        private readonly IXmlAbstractDomainFactoriesFactory _abstractDomainFactoriesFactory;

        public ActrosMP3XmlFactory(XmlNode node, IXmlAbstractDomainFactoriesFactory abstractDomainFactoriesFactory)
        {
            _nodes = node.ChildNodes.ToList();
            _abstractDomainFactoriesFactory = abstractDomainFactoriesFactory;
        }

        public ActrosMP3 Create()
        {
            var factory = _abstractDomainFactoriesFactory.CreateFactory<Semitrailer>(_nodes.GetNode("Semitrailer"));
            return new ActrosMP3(factory?.Create());
        }
    }
}
