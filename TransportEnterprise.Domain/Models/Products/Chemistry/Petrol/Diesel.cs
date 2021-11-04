using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents diesel instance
    /// </summary>
    public class Diesel : Petrol, IEquatable<Diesel>
    {
        /// <summary>
        /// Initializes new diesel instance
        /// </summary>
        public Diesel(decimal weight, decimal value, ICollection<ChemistryDanger> chemistryDangers, string description)
            : base(weight, value, chemistryDangers, description)
        {
        }
        /// <summary>
        /// Checks equality of two diesels
        /// </summary>
        public bool Equals(Diesel other) => base.Equals(other);
        /// <summary>
        /// Check equality of diesel with specified object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) => Equals(obj as Diesel);
        /// <summary>
        /// Gets hash code of diesel
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => base.GetHashCode();
    }
}
