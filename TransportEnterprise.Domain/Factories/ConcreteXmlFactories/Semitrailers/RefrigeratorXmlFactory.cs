using System;
using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class RefrigeratorXmlFactory : SemitrailersBaseXmlFactory, IXmlDomainFactory<Refrigerator>
    {
        private readonly ITemperatureRuleXmlFactory _temperatureRuleXmlFactory;

        public RefrigeratorXmlFactory(IXmlAbstractDomainFactory<Product> productsAbstractXmlFactory,
                                      ITemperatureRuleXmlFactory temperatureRuleXmlFactory) :
                                      base(productsAbstractXmlFactory)
        {
            _temperatureRuleXmlFactory = temperatureRuleXmlFactory;
        }
        public Refrigerator Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (loadCapacity, valueCapacity, products) = GetSemitrailerParameters(nodes);
            var noiseDb = int.Parse(nodes.GetInnerText("NoiseLevelInDecibels"));
            var temperatureRule = _temperatureRuleXmlFactory.CreateTemperatureRule(nodes.GetNode("TemperatureRule"));
            var refrigerator = new Refrigerator(loadCapacity, valueCapacity, temperatureRule, noiseDb);
            foreach (var product in products)
            {
                refrigerator.Load(product);
            }
            return refrigerator;
        }
    }
}
