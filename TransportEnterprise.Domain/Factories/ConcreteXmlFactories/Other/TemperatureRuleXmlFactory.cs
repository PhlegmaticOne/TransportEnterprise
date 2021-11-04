using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class TemperatureRuleXmlFactory : ITemperatureRuleXmlFactory
    {
        public TemperatureRule Create(XmlNode node)
        {
            var temperatureNode = node.ChildNodes.ToList();
            return new TemperatureRule(
                double.Parse(temperatureNode.GetInnerText("MinimalTemperature")),
                double.Parse(temperatureNode.GetInnerText("MaximumTemperature")));
        }
    }
}
