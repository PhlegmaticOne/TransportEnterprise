using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories.ConcreteXmlFactories.Products.CustomerGoods
{
    public class SausageXmlFactory : ProductsBaseXmlFactory, IXmlDomainFactory<Sausage>
    {
        private readonly ITemperatureRuleXmlFactory _temperatureRuleXmlFactory;

        public SausageXmlFactory(ITemperatureRuleXmlFactory temperatureRuleXmlFactory)
        {
            _temperatureRuleXmlFactory = temperatureRuleXmlFactory;
        }
        public Sausage Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description) = GetProductParameters(nodes);
            var sausageType = nodes.GetNode("SausageType").ToSausageType();
            var temperatureRule = _temperatureRuleXmlFactory.CreateTemperatureRule(nodes.GetNode("TemperatureRule"));
            return new Sausage(weight, value, description, sausageType, temperatureRule);
        }
    }
}
