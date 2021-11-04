using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    public interface ITemperatureRuleXmlFactory
    {
        TemperatureRule CreateTemperatureRule(XmlNode node);
    }
}
