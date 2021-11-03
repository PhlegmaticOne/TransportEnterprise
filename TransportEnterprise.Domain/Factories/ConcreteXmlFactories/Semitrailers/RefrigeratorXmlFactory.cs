using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class RefrigeratorXmlFactory : IDomainFactory<Refrigerator>
    {
        private readonly ICollection<XmlNode> _nodes;
        private readonly IXmlAbstractDomainFactoriesFactory _abstractDomainFactoriesFactory;

        public RefrigeratorXmlFactory(XmlNode node, IXmlAbstractDomainFactoriesFactory abstractDomainFactoriesFactory)
        {
            _nodes = node.ChildNodes.ToList();
            _abstractDomainFactoriesFactory = abstractDomainFactoriesFactory;
        }

        public Refrigerator Create()
        {
            var loadCapacity = decimal.Parse(_nodes.GetInnerText("LoadCapacity"));
            var valueCapacity = decimal.Parse(_nodes.GetInnerText("ValueCapacity"));
            var noiseDb = int.Parse(_nodes.GetInnerText("NoiseLevelInDecibels"));
            var xmlProducts = _nodes.GetNode("Products");
            var temperatureNode = _nodes.GetNode("TemperatureRule").ChildNodes.ToList();
            var temperatureRule = new TemperatureRule(
                double.Parse(temperatureNode.GetInnerText("MinimalTemperature")),
                double.Parse(temperatureNode.GetInnerText("MaximumTemperature"))
                );
            var refrigerator = new Refrigerator(loadCapacity, valueCapacity, temperatureRule, noiseDb);
            foreach (XmlNode product in xmlProducts)
            {
                var factory = _abstractDomainFactoriesFactory.CreateFactory<Product>(product);
                refrigerator.Load(factory.Create());
            }
            return refrigerator;
        }
    }
}
