using System.Drawing;

namespace TransportEnterprise.Models
{
    public class Wood : Material
    {
        public Wood(decimal price, Color color, WoodType woodType) : base(price, color)
        {
            WoodType = woodType;
        }
        public WoodType WoodType { get; }
    }
    public enum WoodType
    {
        Oak,
        Pine,
        Birch
    }
}
