namespace TransportEnterprise.Models.Factories
{
    public class SemitrailersXmlAbstractFactory : XmlAbstractDomainFactory<Semitrailer>
    {
        private readonly IXmlAbstractDomainFactory<Product> _productsAbstractXmlFactory;
        private readonly ITemperatureRuleXmlFactory _temperatureRuleXmlFactory;

        public SemitrailersXmlAbstractFactory(IXmlAbstractDomainFactory<Product> productsAbstractXmlFactory,
                                              ITemperatureRuleXmlFactory temperatureRuleXmlFactory)
        {
            _productsAbstractXmlFactory = productsAbstractXmlFactory;
            _temperatureRuleXmlFactory = temperatureRuleXmlFactory;
            InitializeFactories();
        }
        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "Refrigerator", new RefrigeratorXmlFactory(_productsAbstractXmlFactory, _temperatureRuleXmlFactory) },
                { "TankTruck", new TankTruckXmlFactory(_productsAbstractXmlFactory) }
            };
        }
    }
}
