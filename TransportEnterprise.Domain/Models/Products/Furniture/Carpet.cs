using System;

namespace TransportEnterprise.Models
{
    public class Carpet : Furniture, IEquatable<Carpet>
    {
        /// <summary>
        /// Initializes new carpet instance
        /// </summary>
        /// <param name="weight">Specified weight</param>
        /// <param name="value">Specified value</param>
        /// <param name="description">Specified description</param>
        /// <param name="material">Specified furnirure material</param>
        /// <param name="furniturePurpose">Specified furniture purpose</param>
        public Carpet(decimal weight, decimal value, string description,
                     Material material, FurniturePurpose furniturePurpose) :
                     base(weight, value, description, material, furniturePurpose)
        {
        }
        /// <summary>
        /// Checks equality of two carpets
        /// </summary>
        public bool Equals(Carpet other) => base.Equals(other);
        /// <summary>
        /// Check equality of carpet with specified object
        /// </summary>
        public override bool Equals(object obj) => Equals(obj as Carpet);
        /// <summary>
        /// Gets hash code of carpet
        /// </summary>
        public override int GetHashCode() => base.GetHashCode();
    }
}
