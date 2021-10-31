using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class ActrosMP2XmlFactory : IDomainFactory<ActrosMP2>
    {
        private readonly ICollection<XmlNode> _nodes;
        private readonly IXmlAbstractDomainFactoriesFactory _abstractDomainFactoriesFactory;

        public ActrosMP2XmlFactory(XmlNode node, IXmlAbstractDomainFactoriesFactory abstractDomainFactoriesFactory)
        {
            _nodes = node.ChildNodes.ToList();
            _abstractDomainFactoriesFactory = abstractDomainFactoriesFactory;
        }

        public ActrosMP2 Create()
        {
            var factory = _abstractDomainFactoriesFactory.CreateFactory<Semitrailer>(_nodes.GetNode("Semitrailer"));
            return new ActrosMP2(factory.Create());
        }
    }
}
