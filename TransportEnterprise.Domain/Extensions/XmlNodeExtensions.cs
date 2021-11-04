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
            "Benign" => ChemistryDanger.Benign,
            _ => ChemistryDanger.Benign
        };

        public static CocaColaTaste ToCocaColaTaste(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "ClassicWithoutSugar" => CocaColaTaste.ClassicWithoutSugar,
            "ClassicWithSugar" => CocaColaTaste.ClassicWithSugar,
            "Orange" => CocaColaTaste.Orange,
            "Lemon" => CocaColaTaste.Lemon,
            "Vanilla" => CocaColaTaste.Vanilla,
            _ => CocaColaTaste.ClassicWithSugar
        };
        public static MilkTaste ToMilkTaste(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "Cow" => MilkTaste.Cow,
            "Chocolate" => MilkTaste.Chocolate,
            "Soy" => MilkTaste.Soy,
            _ => MilkTaste.Cow
        };
        public static SausageType ToSausageType(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "Cow" => SausageType.Cow,
            "Chicken" => SausageType.Chicken,
            "Pork" => SausageType.Pork,
            "Soy" => SausageType.Soy,
            _ => SausageType.Soy
        }; 
        public static FurniturePurpose ToFurniturePurpose(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "Kitchen" => FurniturePurpose.Kitchen,
            "Bedroom" => FurniturePurpose.Bedroom,
            "Bathroom" => FurniturePurpose.Bathroom,
            "Hall" => FurniturePurpose.Hall,
            _ => FurniturePurpose.Kitchen,
        };
        public static TextileType ToTextileType(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "Silk" => TextileType.Silk,
            "Wool" => TextileType.Wool,
            _ => TextileType.Silk
        };
        public static WoodType ToWoodType(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "Oak" => WoodType.Oak,
            "Birch" => WoodType.Birch,
            "Pine" => WoodType.Pine,
            _ => WoodType.Oak
        };
    }
}
