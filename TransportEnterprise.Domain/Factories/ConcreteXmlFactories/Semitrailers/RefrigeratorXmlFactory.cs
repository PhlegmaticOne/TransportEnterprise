using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;
using TransportEnterprise.Models.Factories.AbstractXmlFactories;

namespace TransportEnterprise.Models.Factories
{
    public class RefrigeratorXmlFactory : IDomainFactory<Refrigerator>
    {
        private readonly ICollection<XmlNode> _nodes;
        public RefrigeratorXmlFactory(XmlNode node) => _nodes = node.ChildNodes.ToList();
        public Refrigerator Create()
        {
            var loadCapacity = decimal.Parse(_nodes.GetInnerText("LoadCapacity"));
            var noiseDb = int.Parse(_nodes.GetInnerText("NoiseLevelInDecibels"));
            var xmlProducts = _nodes.GetNode("Products");
            var temperatureRule = new TemperatureRule(
                int.Parse(_nodes.GetInnerText("MinimalTemperature")),
                int.Parse(_nodes.GetInnerText("MaximumTemperature"))
                );
            var refrigerator = new Refrigerator(loadCapacity, temperatureRule, noiseDb);
            foreach (XmlNode product in xmlProducts)
            {
                var factory = XmlAbstractDomainFactoriesFactory.CreateInstance<Product>(product);
                refrigerator.Load(factory.Create());
            }
            return refrigerator;
        }
    }
}
