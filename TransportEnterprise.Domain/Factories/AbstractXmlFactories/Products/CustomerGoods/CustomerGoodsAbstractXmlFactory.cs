namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents customer goods abstract factory
    /// </summary>
    public class CustomerGoodsAbstractXmlFactory : XmlAbstractDomainFactory<CustomerGood>
    {
        /// <summary>
        /// Temperature rule xml factory
        /// </summary>
        private readonly ITemperatureRuleXmlFactory _temperatureRuleXmlFactory;
        /// <summary>
        /// Initialzies new customer goods abstract factory
        /// </summary>
        /// <param name="temperatureRuleXmlFactory">Temperature rule xml factory</param>
        public CustomerGoodsAbstractXmlFactory(ITemperatureRuleXmlFactory temperatureRuleXmlFactory)
        {
            _temperatureRuleXmlFactory = temperatureRuleXmlFactory;
            InitializeFactories();
        }
        /// <summary>
        /// Initializes factories for types inheriting customer good
        /// </summary>
        protected override void InitializeFactories()
        {
            Factories = new()
            {
                { "CocaCola", new CocaColaXmlFactory() },
                { "Milk", new MilkXmlFactory(_temperatureRuleXmlFactory) },
                { "Sausage", new SausageXmlFactory(_temperatureRuleXmlFactory) },
            };
        }
    }
}
