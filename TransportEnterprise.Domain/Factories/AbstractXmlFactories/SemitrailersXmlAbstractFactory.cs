using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    public class SemitrailersXmlAbstractFactory : XmlAbstractDomainFactory<Semitrailer>
    {
        private readonly IXmlAbstractDomainFactoriesFactory _abstractDomainFactoriesFactory;

        
        public SemitrailersXmlAbstractFactory(XmlNode node, IXmlAbstractDomainFactoriesFactory abstractDomainFactoriesFactory) : base(node)
        {
            _abstractDomainFactoriesFactory = abstractDomainFactoriesFactory;
            InitializeFactories();
        }
        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "Refrigerator", new RefrigeratorXmlFactory(Node, _abstractDomainFactoriesFactory) },
                { "TankTruck", new TankTruckXmlFactory(Node, _abstractDomainFactoriesFactory) }
            };
        }
    }
}
