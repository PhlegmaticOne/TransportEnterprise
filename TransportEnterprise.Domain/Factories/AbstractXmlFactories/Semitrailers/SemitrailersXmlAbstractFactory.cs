namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents abstract xml factory of semitrailers
    /// </summary>
    public class SemitrailersXmlAbstractFactory : XmlAbstractDomainFactory<Semitrailer>
    {
        /// <summary>
        /// Abstract product xml factory
        /// </summary>
        protected readonly IXmlAbstractDomainFactory<Product> ProductsAbstractXmlFactory;
        /// <summary>
        /// Temperature rule xml factory
        /// </summary>
        protected readonly ITemperatureRuleXmlFactory TemperatureRuleXmlFactory;
        /// <summary>
        /// Initializes new semitrailers abstract xml factory
        /// </summary>
        /// <param name="productsAbstractXmlFactory">Specified products abstract xml factory</param>
        /// <param name="temperatureRuleXmlFactory">Specified temperature rule factory</param>
        public SemitrailersXmlAbstractFactory(IXmlAbstractDomainFactory<Product> productsAbstractXmlFactory,
                                              ITemperatureRuleXmlFactory temperatureRuleXmlFactory)
        {
            ProductsAbstractXmlFactory = productsAbstractXmlFactory;
            TemperatureRuleXmlFactory = temperatureRuleXmlFactory;
            InitializeFactories();
        }
        /// <summary>
        /// Initializes all factories of types inherits semitrailers
        /// </summary>
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
