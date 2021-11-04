namespace TransportEnterprise.Models.Factories
{
    public class SemitrailersXmlAbstractFactory : XmlAbstractDomainFactory<Semitrailer>
    {
        protected readonly IXmlAbstractDomainFactory<Product> ProductsAbstractXmlFactory;
        protected readonly ITemperatureRuleXmlFactory TemperatureRuleXmlFactory;

        public SemitrailersXmlAbstractFactory(IXmlAbstractDomainFactory<Product> productsAbstractXmlFactory,
                                              ITemperatureRuleXmlFactory temperatureRuleXmlFactory)
        {
            ProductsAbstractXmlFactory = productsAbstractXmlFactory;
            TemperatureRuleXmlFactory = temperatureRuleXmlFactory;
            InitializeFactories();
        }
        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "Refrigerator", new RefrigeratorXmlFactory(ProductsAbstractXmlFactory, TemperatureRuleXmlFactory) },
                { "TankTruck", new TankTruckXmlFactory(ProductsAbstractXmlFactory) },
                { "TiltSemitrailer", new TiltSemitrailerXmlFactory(ProductsAbstractXmlFactory) }
            };
        }
    }
}
