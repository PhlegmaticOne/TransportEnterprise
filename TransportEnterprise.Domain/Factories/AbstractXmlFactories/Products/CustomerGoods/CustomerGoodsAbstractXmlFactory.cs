namespace TransportEnterprise.Models.Factories
{
    public class CustomerGoodsAbstractXmlFactory : XmlAbstractDomainFactory<CustomerGood>
    {
        private readonly ITemperatureRuleXmlFactory _temperatureRuleXmlFactory;

        public CustomerGoodsAbstractXmlFactory(ITemperatureRuleXmlFactory temperatureRuleXmlFactory)
        {
            _temperatureRuleXmlFactory = temperatureRuleXmlFactory;
            InitializeFactories();
        }
        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "CocaCola", new CocaColaXmlFactory() },
                { "Milk", new MilkXmlFactory(_temperatureRuleXmlFactory) },
            };
        }
    }
}
