using System.Xml;

namespace TransportEnterprise.Models.Extensions
{
    /// <summary>
    /// Extensions for XmlNode
    /// </summary>
    public static class XmlNodeExtensions
    {
        /// <summary>
        /// Converts XmlNode to chemistry danger depending on a inner text of node
        /// </summary>
        public static ChemistryDanger ToChemistryDanger(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "Explosive" => ChemistryDanger.Explosive,
            "Flammable" => ChemistryDanger.Flammable,
            "Toxic" => ChemistryDanger.Toxic,
            "Benign" => ChemistryDanger.Benign,
            _ => ChemistryDanger.Benign
        };
        /// <summary>
        /// Converts XmlNode to coca cola taste depending on a inner text of node
        /// </summary>
        public static CocaColaTaste ToCocaColaTaste(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "ClassicWithoutSugar" => CocaColaTaste.ClassicWithoutSugar,
            "ClassicWithSugar" => CocaColaTaste.ClassicWithSugar,
            "Orange" => CocaColaTaste.Orange,
            "Lemon" => CocaColaTaste.Lemon,
            "Vanilla" => CocaColaTaste.Vanilla,
            _ => CocaColaTaste.ClassicWithSugar
        };
        /// <summary>
        /// Converts XmlNode to milk taste depending on a inner text of node
        /// </summary>
        public static MilkTaste ToMilkTaste(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "Cow" => MilkTaste.Cow,
            "Chocolate" => MilkTaste.Chocolate,
            "Soy" => MilkTaste.Soy,
            _ => MilkTaste.Cow
        };
        /// <summary>
        /// Converts XmlNode to sausage type depending on a inner text of node
        /// </summary>
        public static SausageType ToSausageType(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "Cow" => SausageType.Cow,
            "Chicken" => SausageType.Chicken,
            "Pork" => SausageType.Pork,
            "Soy" => SausageType.Soy,
            _ => SausageType.Soy
        };
        /// <summary>
        /// Converts XmlNode to furniture purpose depending on a inner text of node
        /// </summary>
        public static FurniturePurpose ToFurniturePurpose(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "Kitchen" => FurniturePurpose.Kitchen,
            "Bedroom" => FurniturePurpose.Bedroom,
            "Bathroom" => FurniturePurpose.Bathroom,
            "Hall" => FurniturePurpose.Hall,
            _ => FurniturePurpose.Kitchen,
        };
        /// <summary>
        /// Converts XmlNode to textile type depending on a inner text of node
        /// </summary>
        public static TextileType ToTextileType(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "Silk" => TextileType.Silk,
            "Wool" => TextileType.Wool,
            _ => TextileType.Silk
        };
        /// <summary>
        /// Converts XmlNode to wood type depending on a inner text of node
        /// </summary>
        public static WoodType ToWoodType(this XmlNode xmlNode) => xmlNode.InnerText.Trim('\t', '\n', '\r') switch
        {
            "Oak" => WoodType.Oak,
            "Birch" => WoodType.Birch,
            "Pine" => WoodType.Pine,
            _ => WoodType.Oak
        };
    }
}
