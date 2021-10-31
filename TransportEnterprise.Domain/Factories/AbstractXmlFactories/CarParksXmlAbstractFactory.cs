using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    public class CarParksXmlAbstractFactory : XmlAbstractDomainFactory<CarPark>
    {
        private readonly IXmlAbstractDomainFactoriesFactory _abstractDomainFactoriesFactory;

        public CarParksXmlAbstractFactory(XmlNode node, IXmlAbstractDomainFactoriesFactory abstractDomainFactoriesFactory) : base(node)
        {
            _abstractDomainFactoriesFactory = abstractDomainFactoriesFactory;
            InitializeFactories();
        }

        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "CarPark", new CarParkXmlFactory(Node, _abstractDomainFactoriesFactory) },
            };
        }
    }
}
