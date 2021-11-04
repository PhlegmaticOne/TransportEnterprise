using System;
using System.Drawing;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents textile material
    /// </summary>
    public class Textile : Material, IEquatable<Textile>
    {
        /// <summary>
        /// Initializes new textile instance
        /// </summary>
        /// <param name="price">Specified price</param>
        /// <param name="color">Cpecified color</param>
        /// <param name="textileType">Specified textile type</param>
        public Textile(decimal price, Color color, TextileType textileType) : base(price, color) => 
            TextileType = textileType;
        /// <summary>
        /// Textyle type
        /// </summary>
        public TextileType TextileType { get; }
        /// <summary>
        /// Checks equality of two textiles
        /// </summary>
        public bool Equals(Textile other) => other.TextileType == TextileType && base.Equals(other);
        /// <summary>
        /// Check equality of textiles with specified object
        /// </summary>
        public override bool Equals(object obj) => Equals(obj as Textile);
        /// <summary>
        /// Gets hash code of textile
        /// </summary>
        public override int GetHashCode() => base.GetHashCode();
        /// <summary>
        /// Gets string representation of textile
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Format("{0}. Textile type: {1}", base.ToString(), TextileType);
    }
    /// <summary>
    /// Represents textile type
    /// </summary>
    public enum TextileType
    {
        Silk,
        Wool
    }
}
