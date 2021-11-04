using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class ChemistryXmlAbstractFactory : XmlAbstractDomainFactory<Chemistry>
    {
        private readonly IXmlAbstractDomainFactory<Petrol> _petrolXmlAbstractFactory;
        private readonly ITemperatureRuleXmlFactory _temperatureRuleXmlFactory;

        public ChemistryXmlAbstractFactory(IXmlAbstractDomainFactory<Petrol> petrolXmlAbstractFactory,
                                           ITemperatureRuleXmlFactory temperatureRuleXmlFactory)
        {
            _petrolXmlAbstractFactory = petrolXmlAbstractFactory;
            _temperatureRuleXmlFactory = temperatureRuleXmlFactory;
            InitializeFactories();
        }
        protected override void InitializeFactories()
        {
            Factories = new(_petrolXmlAbstractFactory.ToKeyValuePairs<Chemistry>());
            Factories.Add("Methylamine", new MethylamineXmlFactory(_temperatureRuleXmlFactory));
            Factories.Add("Carbon", new CarbonXmlFactory());
        }
    }
}
