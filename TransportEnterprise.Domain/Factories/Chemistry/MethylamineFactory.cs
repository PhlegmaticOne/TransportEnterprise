using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class MethylamineFactory : IDomainFactory<Methylamine>
    {
        public Methylamine Create(ICollection<XmlNode> xmlNodes)
        {
            var weight = decimal.Parse(xmlNodes.First(n => n.OuterXml.Contains("Weight")).InnerText);
            var description = xmlNodes.First(n => n.OuterXml.Contains("Description")).InnerText;
            var xmlChemistryDangers = xmlNodes.First(n => n.OuterXml.Contains("ChemistryDangers"));
            var chemistryDangers = new List<ChemistryDanger>();
            foreach (XmlNode danger in xmlChemistryDangers)
            {
                chemistryDangers.Add(danger.ToChemistryDanger());
            }
            var temperatures = xmlNodes.First(n => n.OuterXml.Contains("TemperatureRule")).ChildNodes.ToList();
            var temperatureRule = new TemperatureRule(
                int.Parse(xmlNodes.First(n => n.OuterXml.Contains("MinimalTemperature")).InnerText),
                int.Parse(xmlNodes.First(n => n.OuterXml.Contains("MaximumTemperature")).InnerText
                ));
            return new Methylamine(weight, chemistryDangers, temperatureRule, description);
        }
    }
}
