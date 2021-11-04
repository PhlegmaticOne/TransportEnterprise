using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents petrol A98 instance
    /// </summary>
    public class PetrolA98 : Petrol, IEquatable<PetrolA98>
    {
        /// <summary>
        /// Initializes new Petrol A98 instance
        /// </summary>
        public PetrolA98(decimal weight, decimal value, ICollection<ChemistryDanger> chemistryDangers, string description = "Petrol A98") :
            base(weight, value, chemistryDangers, description)
        {
        }
        /// <summary>
        /// Checks equality of two petrolsA98
        /// </summary>
        public bool Equals(PetrolA98 other) => base.Equals(other);
        /// <summary>
        /// Check equality of petrolA98 with specified object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) => Equals(obj as PetrolA98);
        /// <summary>
        /// Gets hash code of petrolA98
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => base.GetHashCode();
    }
}
