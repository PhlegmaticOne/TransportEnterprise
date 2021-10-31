using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    public class TruckTractorsXmlAbstractFactory : XmlAbstractDomainFactory<TruckTractor>
    {
        private readonly IXmlAbstractDomainFactoriesFactory _abstractDomainFactoriesFactory;

        public TruckTractorsXmlAbstractFactory(XmlNode node, IXmlAbstractDomainFactoriesFactory abstractDomainFactoriesFactory) : base(node)
        {
            _abstractDomainFactoriesFactory = abstractDomainFactoriesFactory;
            InitializeFactories();
        }
        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "ActrosMP2", new ActrosMP2XmlFactory(Node, _abstractDomainFactoriesFactory) }
            };
        }
    }
}
