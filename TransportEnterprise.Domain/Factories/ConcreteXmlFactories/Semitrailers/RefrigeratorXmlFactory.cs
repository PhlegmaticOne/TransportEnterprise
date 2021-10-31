﻿using System.Collections.Generic;
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
            var noiseDb = int.Parse(_nodes.GetInnerText("NoiseLevelInDecibels"));
            var xmlProducts = _nodes.GetNode("Products");
            var temperatureRule = new TemperatureRule(
                int.Parse(_nodes.GetInnerText("MinimalTemperature")),
                int.Parse(_nodes.GetInnerText("MaximumTemperature"))
                );
            var refrigerator = new Refrigerator(loadCapacity, temperatureRule, noiseDb);
            foreach (XmlNode product in xmlProducts)
            {
                var factory = _abstractDomainFactoriesFactory.CreateFactory<Product>(product);
                refrigerator.Load(factory.Create());
            }
            return refrigerator;
        }
    }
}