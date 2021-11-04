using System.Drawing;

namespace TransportEnterprise.Models
{
    public class Textile : Material
    {
        public Textile(decimal price, Color color, TextileType textileType) : base(price, color)
        {
            TextileType = textileType;
        }

        public TextileType TextileType { get; }
    }
    public enum TextileType
    {
        Silk,
        Wool
    }
}
