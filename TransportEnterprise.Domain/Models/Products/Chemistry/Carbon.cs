using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents carbon
    /// </summary>
    public class Carbon : Chemistry, IEquatable<Carbon>
    {
        /// <summary>
        /// Initializes new carbon instance
        /// </summary>
        /// <param name="weight">Specified weight</param>
        /// <param name="value">Specified value</param>
        /// <param name="chemistryDangers">Specified chemistry dangers</param>
        /// <param name="description">Specified description</param>
        public Carbon(decimal weight, decimal value,
                      ICollection<ChemistryDanger> chemistryDangers, string description) :
                      base(weight, value, chemistryDangers, description)
        {
        }
        /// <summary>
        /// Checks equality of two carbons
        /// </summary>
        public bool Equals(Carbon other) => base.Equals(other);
        /// <summary>
        /// Check equality of carbons with specified object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) => Equals(obj as Carbon);
        /// <summary>
        /// Gets hash code of carbon
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => base.GetHashCode();
    }
}
