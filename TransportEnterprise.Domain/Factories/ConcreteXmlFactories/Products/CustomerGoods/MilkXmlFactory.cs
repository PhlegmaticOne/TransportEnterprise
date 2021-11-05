using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents milk xml factory
    /// </summary>
    public class MilkXmlFactory : ProductsBaseXmlFactory, IXmlDomainFactory<Milk>
    {
        /// <summary>
        /// Temperature rule xml factory
        /// </summary>
        private readonly ITemperatureRuleXmlFactory _temperatureRuleXmlFactory;
        /// <summary>
        /// Initializes new milk xml factory
        /// </summary>
        /// <param name="temperatureRuleXmlFactory">Specified temperature rule xml factory</param>
        public MilkXmlFactory(ITemperatureRuleXmlFactory temperatureRuleXmlFactory) => 
            _temperatureRuleXmlFactory = temperatureRuleXmlFactory;
        /// <summary>
        /// Creates milk from xml node
        /// </summary>
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
