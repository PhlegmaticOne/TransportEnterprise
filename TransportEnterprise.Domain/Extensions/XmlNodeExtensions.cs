using System.Xml;

namespace TransportEnterprise.Models.Extensions
{
    public static class XmlNodeExtensions
    {
        public static ChemistryDanger ToChemistryDanger(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "Explosive" => ChemistryDanger.Explosive,
            "Flammable" => ChemistryDanger.Flammable,
            "Toxic" => ChemistryDanger.Toxic,
            _ => ChemistryDanger.Benign
        };

        public static CocaColaTaste ToCocaColaTaste(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "ClassicWithoutSugar" => CocaColaTaste.ClassicWithoutSugar,
            "Orange" => CocaColaTaste.Orange,
            "Lemon" => CocaColaTaste.Lemon,
            "Vanilla" => CocaColaTaste.Vanilla,
            _ => CocaColaTaste.ClassicWithSugar
        };
    }
}
