using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class MilkXmlFactory : ProductsBaseXmlFactory, IXmlDomainFactory<Milk>
    {
        private readonly ITemperatureRuleXmlFactory _temperatureRuleXmlFactory;

        public MilkXmlFactory(ITemperatureRuleXmlFactory temperatureRuleXmlFactory)
        {
            _temperatureRuleXmlFactory = temperatureRuleXmlFactory;
        }
        public Milk Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description) = GetProductParameters(nodes);
            var milkTaste = nodes.GetNode("MilkTaste").ToMilkTaste();
            var temperatureRule = _temperatureRuleXmlFactory.CreateTemperatureRule(nodes.GetNode("TemperatureRule"));
            return new Milk(weight, value, description, temperatureRule, milkTaste);
        }
    }
}
