using System;
using System.Drawing;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents base instance for materials
    /// </summary>
    public abstract class Material : IEquatable<Material>
    {
        /// <summary>
        /// Initializes new material instance
        /// </summary>
        /// <param name="price">Specified price</param>
        /// <param name="color">Cpecified color</param>
        protected Material(decimal price, Color color)
        {
            Price = price >= 0 ? price : throw new ArgumentException("Price cannot be less than or equal zero", nameof(price));
            Color = color;
        }
        /// <summary>
        /// Price of material
        /// </summary>
        public decimal Price { get; }
        /// <summary>
        /// Color of material
        /// </summary>
        public Color Color { get; }
        /// <summary>
        /// Checks equality of two materials
        /// </summary>
        public bool Equals(Material other) => other.Price == Price && Color == other.Color;
        /// <summary>
        /// Check equality of mateial with specified object
        /// </summary>
        public override bool Equals(object obj) => Equals(obj as Material);
        /// <summary>
        /// Gets hash code of material
        /// </summary>
        public override int GetHashCode() => (int)Price * Color.ToArgb();
        /// <summary>
        /// Gets string representation of material
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Format("Price: {0:f4}. Color: {1}", Price, Color);
    }
}
