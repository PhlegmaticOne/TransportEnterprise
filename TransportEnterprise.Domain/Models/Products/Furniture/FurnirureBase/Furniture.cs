using System;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents base class for furniture
    /// </summary>
    public abstract class Furniture : Product, IEquatable<Furniture>
    {
        /// <summary>
        /// Initializes new furniture instance
        /// </summary>
        /// <param name="weight">Specified weight</param>
        /// <param name="value">Specified value</param>
        /// <param name="description">Specified description</param>
        /// <param name="material">Specified furnirure material</param>
        /// <param name="furniturePurpose">Specified furniture purpose</param>
        protected Furniture(decimal weight, decimal value, string description,
                               Material material, FurniturePurpose furniturePurpose) :
                               base(weight, value, description)
        {
            Material = material ?? throw new System.ArgumentNullException(nameof(material));
            FurniturePurpose = furniturePurpose;
        }
        /// <summary>
        /// Furniture material
        /// </summary>
        public Material Material { get; }
        /// <summary>
        /// Furniture purpose
        /// </summary>
        public FurniturePurpose FurniturePurpose { get; }
        /// <summary>
        /// Checks equality of two furnitures
        /// </summary>
        public bool Equals(Furniture other) => other.Material.Equals(Material) && FurniturePurpose == other.FurniturePurpose &&
                                                base.Equals(other);
        /// <summary>
        /// Check equality of furniture with specified object
        /// </summary>
        public override bool Equals(object obj) => Equals(obj as Furniture);
        /// <summary>
        /// Gets hash code of furniture
        /// </summary>
        public override int GetHashCode() => Material.GetHashCode() * (int)FurniturePurpose;
        /// <summary>
        /// Gets string representation of furniture
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            string.Format("{0}. Purpose: {1}. Material: {2}", base.ToString(), FurniturePurpose, Material.ToString());
    }
    /// <summary>
    /// Represents furnirure purpose
    /// </summary>
    public enum FurniturePurpose
    {
        Kitchen,
        Bedroom,
        Hall,
        Bathroom
    }
}
