using System;

namespace TransportEnterprise.Models
{
    public class Wardrobe : Furniture, IEquatable<Wardrobe>
    {
        /// <summary>
        /// Initializes new wardrobe instance
        /// </summary>
        /// <param name="weight">Specified weight</param>
        /// <param name="value">Specified value</param>
        /// <param name="description">Specified description</param>
        /// <param name="material">Specified furnirure material</param>
        /// <param name="furniturePurpose">Specified furniture purpose</param>
        public Wardrobe(decimal weight, decimal value, string description,
                        Material material, FurniturePurpose furniturePurpose) :
                        base(weight, value, description, material, furniturePurpose)
        {
        }
        /// <summary>
        /// Checks equality of two wardrobes
        /// </summary>
        public bool Equals(Wardrobe other) => base.Equals(other);
        /// <summary>
        /// Check equality of wardrobe with specified object
        /// </summary>
        public override bool Equals(object obj) => Equals(obj as Wardrobe);
        /// <summary>
        /// Gets hash code of wardrobe
        /// </summary>
        public override int GetHashCode() => base.GetHashCode();
    }
}
