using System.Collections.Generic;
using System.Xml;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models.Factories
{
    public class PetrolXmlFactory : IDomainFactory<PetrolA92>
    {
        private readonly ICollection<XmlNode> _nodes;
        public PetrolXmlFactory(XmlNode node)
        {
            _nodes = node.ChildNodes.ToList();
        }
        public PetrolA92 Create()
        {
            var xmlDangers = _nodes.GetNode("ChemistryDangers");
            var dangers = new List<ChemistryDanger>();
            foreach (XmlNode xmlDanger in xmlDangers)
            {
                dangers.Add(xmlDanger.ToChemistryDanger());
            }
            var weight = int.Parse(_nodes.GetInnerText("Weight"));
            var description = _nodes.GetInnerText("Description");
            return new PetrolA92(weight, dangers, description);
        }
    }
}
