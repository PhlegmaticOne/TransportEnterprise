using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents methylamine xml factory
    /// </summary>
    public class MethylamineXmlFactory : ChemistryBaseXmlFactory, IXmlDomainFactory<Methylamine>
    {
        /// <summary>
        /// Temperature rule xml factory
        /// </summary>
        private readonly ITemperatureRuleXmlFactory _temperatureRuleXmlFactory;
        /// <summary>
        /// Initializes new methylamine factory
        /// </summary>
        /// <param name="temperatureRuleXmlFactory">Specified temperature rule factory</param>
        public MethylamineXmlFactory(ITemperatureRuleXmlFactory temperatureRuleXmlFactory) => 
            _temperatureRuleXmlFactory = temperatureRuleXmlFactory;
        /// <summary>
        /// Creates mathylamine from xml node
        /// </summary>
        public Methylamine Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (weight, value, description, dangers) = GetChemistryParameters(nodes);
            var temperatureRule = _temperatureRuleXmlFactory.CreateTemperatureRule(nodes.GetNode("TemperatureRule"));
            return new Methylamine(weight, value, dangers, temperatureRule, description);
        }
    }
}
