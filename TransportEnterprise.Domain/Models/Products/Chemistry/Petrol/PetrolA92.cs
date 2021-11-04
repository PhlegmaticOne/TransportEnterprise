using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents petrol A92 instance
    /// </summary>
    public class PetrolA92 : Petrol, IEquatable<PetrolA92>
    {
        /// <summary>
        /// Initialzes new PetrolA92 instance
        /// </summary>
        public PetrolA92(decimal weight, decimal value, ICollection<ChemistryDanger> chemistryDangers, string description) :
            base(weight, value, chemistryDangers, description)
        {
        }
        /// <summary>
        /// Checks equality of two petrolsA92
        /// </summary>
        public bool Equals(PetrolA92 other) => base.Equals(other);
        /// <summary>
        /// Check equality of petrolA92 with specified object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) => Equals(obj as PetrolA92);
        /// <summary>
        /// Gets hash code of petrolA92
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => base.GetHashCode();
    }
}
