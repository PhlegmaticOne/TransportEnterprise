using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class PetrolA95 : Petrol, IEquatable<PetrolA95>
    {
        public PetrolA95(int id, decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Petrol A95") :
            base(id, weight, chemistryDangers, description)
        { }
        protected PetrolA95(int id, decimal weight, string description) :
            base(id, weight, description) { }
        public bool Equals(PetrolA95 other) => base.Equals(other);
        public override bool Equals(object obj) => obj is PetrolA95 product && Equals(product);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => string.Format("Petrol A95. {0}", base.ToString());
    }
}