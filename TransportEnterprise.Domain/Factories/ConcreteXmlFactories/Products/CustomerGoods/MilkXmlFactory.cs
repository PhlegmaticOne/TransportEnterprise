using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class MilkXmlFactory : IDomainFactory<Milk>
    {
        private readonly ICollection<XmlNode> _nodes;
        public MilkXmlFactory(XmlNode node) => _nodes = node.ChildNodes.ToList();
        public Milk Create()
        {
            var weight = decimal.Parse(_nodes.GetInnerText("Weight"));
            var value = decimal.Parse(_nodes.GetInnerText("Value"));
            var description = _nodes.GetInnerText("Description");
            var milkTaste = _nodes.GetNode("MilkTaste").ToMilkTaste();
            var temperatureNode = _nodes.GetNode("TemperatureRule").ChildNodes.ToList();
            var temperatureRule = new TemperatureRule(
                double.Parse(temperatureNode.GetInnerText("MinimalTemperature")),
                double.Parse(temperatureNode.GetInnerText("MaximumTemperature")));
            return new Milk(weight, value, description, temperatureRule, milkTaste);
        }
    }
}
