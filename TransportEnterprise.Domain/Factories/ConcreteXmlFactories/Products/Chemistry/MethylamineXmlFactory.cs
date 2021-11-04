using System;
using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class MethylamineXmlFactory : ChemistryBaseXmlFactory, IXmlDomainFactory<Methylamine>
    {
        private readonly ITemperatureRuleXmlFactory _temperatureRuleXmlFactory;

        public MethylamineXmlFactory(ITemperatureRuleXmlFactory temperatureRuleXmlFactory)
        {
            _temperatureRuleXmlFactory = temperatureRuleXmlFactory;
        }
        public Methylamine Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description, dangers) = GetChemistryParameters(nodes);
            var temperatureRule = _temperatureRuleXmlFactory.Create(nodes.GetNode("TemperatureRule"));
            return new Methylamine(weight, value, dangers, temperatureRule, description);
        }
    }
}
