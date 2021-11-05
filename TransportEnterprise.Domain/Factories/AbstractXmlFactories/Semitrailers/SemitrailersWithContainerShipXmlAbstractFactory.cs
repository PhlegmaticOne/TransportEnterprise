namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents semitrailers abstract xml factory with new container ship type 
    /// </summary>
    public class SemitrailersWithContainerShipXmlAbstractFactory : SemitrailersXmlAbstractFactory
    {
        /// <summary>
        /// Initializes new semitrailers abstract factory
        /// </summary>
        /// <param name="productsAbstractXmlFactory">Specified products abstract xl factory</param>
        /// <param name="temperatureRuleXmlFactory">Specified temperature rule factory</param>
        public SemitrailersWithContainerShipXmlAbstractFactory(
            IXmlAbstractDomainFactory<Product> productsAbstractXmlFactory,
            ITemperatureRuleXmlFactory temperatureRuleXmlFactory) :
            base(productsAbstractXmlFactory, temperatureRuleXmlFactory)
        {
        }
        /// <summary>
        /// Initializes all factories of types inherits semitrailers
        /// </summary>
        protected override void InitializeFactories()
        {
            base.InitializeFactories();
            Factories.Add("ContainerShip", new ContainerShipXmlFactory(ProductsAbstractXmlFactory));
        }
    }
}
