using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class Diesel : Petrol, IEquatable<Diesel>
    {
        public Diesel(int id, decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Diesel petrol")
            : base(id, weight, chemistryDangers, description)
        {
        }
        protected Diesel(int id, decimal weight, string description) :
            base(id, weight, description)
        {
        }
        public bool Equals(Diesel other) => base.Equals(other);
        public override bool Equals(object obj) => obj is Diesel product && Equals(product);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => string.Format("Diesel. {0}", base.ToString());
    }
}
