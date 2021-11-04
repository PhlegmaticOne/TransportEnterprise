using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents Petrol A95 instance
    /// </summary>
    public class PetrolA95 : Petrol, IEquatable<PetrolA95>
    {
        /// <summary>
        /// Initializes new Petrol A92 instance
        /// </summary>
        public PetrolA95(decimal weight, decimal value, ICollection<ChemistryDanger> chemistryDangers, string description = "Petrol A95") :
            base(weight, value, chemistryDangers, description)
        { }
        /// <summary>
        /// Checks equality of two petrolsA95
        /// </summary>
        public bool Equals(PetrolA95 other) => base.Equals(other);
        /// <summary>
        /// Check equality of petrolA95 with specified object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) => Equals(obj as PetrolA95);
        /// <summary>
        /// Gets hash code of petrolA95
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => base.GetHashCode();
    }
}