using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents abstrct factory for creating types inherited from chemistry
    /// </summary>
    public class ChemistryXmlAbstractFactory : XmlAbstractDomainFactory<Chemistry>
    {
        /// <summary>
        /// Petrol abstract xml factory
        /// </summary>
        private readonly IXmlAbstractDomainFactory<Petrol> _petrolXmlAbstractFactory;
        /// <summary>
        /// Temperature rule xml factory
        /// </summary>
        private readonly ITemperatureRuleXmlFactory _temperatureRuleXmlFactory;
        /// <summary>
        /// Initializes new chemistry xml abstract factory instance
        /// </summary>
        /// <param name="petrolXmlAbstractFactory">Petrol abstract xml factory</param>
        /// <param name="temperatureRuleXmlFactory">Temperature rule xml factory</param>
        public ChemistryXmlAbstractFactory(IXmlAbstractDomainFactory<Petrol> petrolXmlAbstractFactory,
                                           ITemperatureRuleXmlFactory temperatureRuleXmlFactory)
        {
            _petrolXmlAbstractFactory = petrolXmlAbstractFactory;
            _temperatureRuleXmlFactory = temperatureRuleXmlFactory;
            InitializeFactories();
        }
        /// <summary>
        /// Initializes chamistry inherited types factories
        /// </summary>
        protected override void InitializeFactories()
        {
            Factories = new(_petrolXmlAbstractFactory.ToKeyValuePairs<Chemistry>());
            Factories.Add("Methylamine", new MethylamineXmlFactory(_temperatureRuleXmlFactory));
            Factories.Add("Carbon", new CarbonXmlFactory());
        }
    }
}
