namespace TransportEnterprise.Models.Factories
{
    public class SemitrailersWithContainerShipXmlAbstractFactory : SemitrailersXmlAbstractFactory
    {
        public SemitrailersWithContainerShipXmlAbstractFactory(
            IXmlAbstractDomainFactory<Product> productsAbstractXmlFactory,
            ITemperatureRuleXmlFactory temperatureRuleXmlFactory) :
            base(productsAbstractXmlFactory, temperatureRuleXmlFactory)
        {
        }
        protected override void InitializeFactories()
        {
            base.InitializeFactories();
            Factories.Add("ContainerShip", new ContainerShipXmlFactory(ProductsAbstractXmlFactory));
        }
    }
}
