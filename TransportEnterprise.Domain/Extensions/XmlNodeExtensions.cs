using System.Xml;

namespace TransportEnterprise.Models.Extensions
{
    public static class XmlNodeExtensions
    {
        public static ChemistryDanger ToChemistryDanger(this XmlNode xmlNode) => xmlNode.InnerText switch
        {
            "Explosive" => ChemistryDanger.Explosive,
            "Flammable" => ChemistryDanger.Flammable,
            "Toxic" => ChemistryDanger.Toxic,
            _ => ChemistryDanger.Benign
        };
    }
}
