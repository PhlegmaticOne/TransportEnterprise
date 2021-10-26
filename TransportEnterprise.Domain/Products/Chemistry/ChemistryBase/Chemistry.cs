using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    [Serializable]
    public abstract class Chemistry : Product, IEquatable<Chemistry>
    {
        public Chemistry(int id, decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description) :
                        this(id, weight, description) => ChemistryDangers = chemistryDangers;
        protected Chemistry(int id, decimal weight, string description) :
                            base(id, weight, description) { }
        public ICollection<ChemistryDanger> ChemistryDangers { get; }
        public bool Equals(Chemistry other) => base.Equals(other);
        public override bool Equals(object obj) => obj is Chemistry product && Equals(product);
        public override int GetHashCode() => base.GetHashCode();
    }
}
