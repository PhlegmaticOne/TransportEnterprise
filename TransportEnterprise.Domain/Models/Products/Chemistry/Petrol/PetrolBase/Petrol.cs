using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents base instance of petrol
    /// </summary>
    public abstract class Petrol : Chemistry, IEquatable<Petrol>
    {
        /// <summary>
        /// Initializes new petrol instance
        /// </summary>
        /// <param name="weight">Specified weight</param>
        /// <param name="chemistryDangers">Chemisty dangers</param>
        /// <param name="description">Description</param>
        public Petrol(decimal weight, decimal value, ICollection<ChemistryDanger> chemistryDangers, string description) :
            base (weight, value, chemistryDangers, description) { }
        /// <summary>
        /// Checks equality of two petrols
        /// </summary>
        public bool Equals(Petrol other) => base.Equals(other);
        /// <summary>
        /// Check equality of petrol with specified object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) => Equals(obj as Petrol);
        /// <summary>
        /// Gets hash code of petrol
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => base.GetHashCode();
    }
}
