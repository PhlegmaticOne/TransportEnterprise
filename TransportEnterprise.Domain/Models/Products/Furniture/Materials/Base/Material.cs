using System.Drawing;

namespace TransportEnterprise.Models
{
    public abstract class Material
    {
        protected Material(decimal price, Color color)
        {
            Price = price;
            Color = color;
        }
        public decimal Price { get; }
        public Color Color { get; }
    }
}
