using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents sausage xml factory
    /// </summary>
    public class SausageXmlFactory : ProductsBaseXmlFactory, IXmlDomainFactory<Sausage>
    {
        /// <summary>
        /// Temperature rule xml factory
        /// </summary>
        private readonly ITemperatureRuleXmlFactory _temperatureRuleXmlFactory;
        /// <summary>
        /// Initializes new sausage xml factory instance
        /// </summary>
        /// <param name="temperatureRuleXmlFactory">Specified temperature rule xml factory</param>
        public SausageXmlFactory(ITemperatureRuleXmlFactory temperatureRuleXmlFactory) => 
            _temperatureRuleXmlFactory = temperatureRuleXmlFactory;
        /// <summary>
        /// Creates sausage from xml node
        /// </summary>
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
