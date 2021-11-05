using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents refrigerators xml factory
    /// </summary>
    public class RefrigeratorXmlFactory : SemitrailersBaseXmlFactory, IXmlDomainFactory<Refrigerator>
    {
        /// <summary>
        /// Temperature rule xml factory
        /// </summary>
        private readonly ITemperatureRuleXmlFactory _temperatureRuleXmlFactory;
        /// <summary>
        /// Initializes new refrigerator xml factory
        /// </summary>
        /// <param name="productsAbstractXmlFactory">Specified abstract product xml factory</param>
        /// <param name="temperatureRuleXmlFactory">Specified temperature rule xml factory</param>
        public RefrigeratorXmlFactory(IXmlAbstractDomainFactory<Product> productsAbstractXmlFactory,
                                      ITemperatureRuleXmlFactory temperatureRuleXmlFactory) :
                                      base(productsAbstractXmlFactory) => 
                                      _temperatureRuleXmlFactory = temperatureRuleXmlFactory;
        /// <summary>
        /// Creates refrigerator from xml node
        /// </summary>
        public Refrigerator Create(XmlNode node)
        {
            var nodes = node.ChildNodes.ToList();
            var (loadCapacity, valueCapacity, products) = GetSemitrailerParameters(nodes);
            var noiseDb = int.Parse(nodes.GetInnerText("NoiseLevelInDecibels"));
            var temperatureRule = _temperatureRuleXmlFactory.CreateTemperatureRule(nodes.GetNode("TemperatureRule"));
            var refrigerator = new Refrigerator(loadCapacity, valueCapacity, temperatureRule, noiseDb);
            foreach (var product in products)
            {
                refrigerator.Load(product);
            }
            return refrigerator;
        }
    }
}
