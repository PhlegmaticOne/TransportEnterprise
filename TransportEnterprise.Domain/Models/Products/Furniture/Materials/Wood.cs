using System;
using System.Drawing;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents wood material
    /// </summary>
    public class Wood : Material, IEquatable<Wood>
    {
        /// <summary>
        /// Initializes new wood instance
        /// </summary>
        /// <param name="price">Specified price</param>
        /// <param name="color">Cpecified color</param>
        /// <param name="woodType">Specified wood type</param>
        public Wood(decimal price, Color color, WoodType woodType) : base(price, color) => 
            WoodType = woodType;
        /// <summary>
        /// Wood type
        /// </summary>
        public WoodType WoodType { get; }
        /// <summary>
        /// Checks equality of two woods
        /// </summary>
        public bool Equals(Wood other) => other.WoodType == WoodType && base.Equals(other);
        /// <summary>
        /// Check equality of woods with specified object
        /// </summary>
        public override bool Equals(object obj) => Equals(obj as Wood);
        /// <summary>
        /// Gets hash code of wood
        /// </summary>
        public override int GetHashCode() => base.GetHashCode();
        /// <summary>
        /// Gets string representation of wood
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Format("{0}. Wood Type: {1}", base.ToString(), WoodType);
    }
    /// <summary>
    /// Represnts wood type
    /// </summary>
    public enum WoodType
    {
        Oak,
        Pine,
        Birch
    }
}
