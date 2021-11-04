using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents base instance for chemistry
    /// </summary>
    public abstract class Chemistry : Product, IEquatable<Chemistry>
    {
        protected readonly ICollection<ChemistryDanger> _chemistryDangers;
        /// <summary>
        /// Initializes new chemistry instance
        /// </summary>
        /// <param name="weight">Specified weight</param>
        /// <param name="chemistryDangers">Specifued chemistry dangers</param>
        /// <param name="description">Description</param>
        public Chemistry(decimal weight, decimal value, ICollection<ChemistryDanger> chemistryDangers, string description) :
                        base(weight, value, description) => _chemistryDangers = chemistryDangers;
        /// <summary>
        /// Chemistry dangers of current chemistry
        /// </summary>
        public IReadOnlyCollection<ChemistryDanger> ChemistryDangers => new ReadOnlyCollection<ChemistryDanger>(_chemistryDangers.ToList());
        /// <summary>
        /// Checks equality of two chemistry 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Chemistry other) => _chemistryDangers.AllEquals(other._chemistryDangers) && base.Equals(other);
        /// <summary>
        /// Check equality of current chemistryy with specified object
        /// </summary>
        public override bool Equals(object obj) => obj is Chemistry product && Equals(product);
        /// <summary>
        /// Gets hash code of current chemistry instance
        /// </summary>
        public override int GetHashCode() => (int)(ChemistryDangers.GetHashCode() + Weight);
        /// <summary>
        /// Gets string representation of chemistry
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Format("{0}. {1}", string.Join(',', ChemistryDangers), base.ToString());
    }
}
