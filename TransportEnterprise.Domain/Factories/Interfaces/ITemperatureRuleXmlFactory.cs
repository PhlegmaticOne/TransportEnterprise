using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    /// <summary>
    /// Represents contract for creating temperature rule from xml node
    /// </summary>
    public interface ITemperatureRuleXmlFactory
    {
        /// <summary>
        /// Creates temperature rule from xml node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        TemperatureRule CreateTemperatureRule(XmlNode node);
    }
}
