using System;
using System.Collections.Generic;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models
{
    public abstract class Chemistry : Product, IEquatable<Chemistry>
    {
        public Chemistry() { }
        public Chemistry(decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description) :
                        this(weight, description) => ChemistryDangers = chemistryDangers;
        protected Chemistry(decimal weight, string description) :
                            base(weight, description) { }
        public ICollection<ChemistryDanger> ChemistryDangers { get; }
        public bool Equals(Chemistry other) => Weight == other.Weight && Description == other.Description &&
                                               ChemistryDangers.AllEquals(other.ChemistryDangers);
        public override bool Equals(object obj) => obj is Chemistry product && Equals(product);
        public override int GetHashCode() => (int)(ChemistryDangers.GetHashCode() + Weight);
    }
}
