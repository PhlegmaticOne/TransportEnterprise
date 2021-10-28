using System.Collections.Generic;
using System.Xml;

namespace TransportEnterprise.Models.Factories
{
    public interface IChemistryFactory
    {
        Chemistry Create(ICollection<XmlNode> xmlNodes);
    }
}
