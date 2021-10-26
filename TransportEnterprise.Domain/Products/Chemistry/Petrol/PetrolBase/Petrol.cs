using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    [Serializable]
    public abstract class Petrol : Chemistry, IEquatable<Petrol>
    {
        public Petrol(int id, decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Petrol") :
            base(id, weight, chemistryDangers, description)
        { }
        protected Petrol(int id, decimal weight, string description) :
            base(id, weight, description) { }
        public bool Equals(Petrol other) => base.Equals(other);
        public override bool Equals(object obj) => obj is Petrol product && Equals(product);
        public override int GetHashCode() => base.GetHashCode();
    }
}
