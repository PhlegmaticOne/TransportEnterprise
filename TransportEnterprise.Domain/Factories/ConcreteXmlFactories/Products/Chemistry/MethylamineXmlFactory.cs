using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class MethylamineXmlFactory : IDomainFactory<Methylamine>
    {
        private readonly ICollection<XmlNode> _nodes;

        public MethylamineXmlFactory(XmlNode node) => _nodes = node.ChildNodes.ToList();
        public Methylamine Create()
        {
            var weight = decimal.Parse(_nodes.GetInnerText("Weight"));
            var description = _nodes.GetInnerText("Description");
            var xmlChemistryDangers = _nodes.GetNode("ChemistryDangers");
            var chemistryDangers = new List<ChemistryDanger>();
            foreach (XmlNode danger in xmlChemistryDangers)
            {
                chemistryDangers.Add(danger.ToChemistryDanger());
            }
            var temperatureRule = new TemperatureRule(
                int.Parse(_nodes.GetInnerText("MinimalTemperature")),
                int.Parse(_nodes.GetInnerText("MaximumTemperature")));
            return new Methylamine(weight, chemistryDangers, temperatureRule, description);
        }
    }
}
