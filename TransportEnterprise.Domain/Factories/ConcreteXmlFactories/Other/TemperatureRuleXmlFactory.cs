using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents temperature rule xml factory
    /// </summary>
    public class TemperatureRuleXmlFactory : ITemperatureRuleXmlFactory
    {
        /// <summary>
        /// Creates temperature rule from xml node
        /// </summary>
        public TemperatureRule CreateTemperatureRule(XmlNode node)
        {
            var temperatureNode = node.ChildNodes.ToList();
            return new TemperatureRule(
                double.Parse(temperatureNode.GetInnerText("MinimalTemperature")),
                double.Parse(temperatureNode.GetInnerText("MaximumTemperature")));
        }
    }
}
