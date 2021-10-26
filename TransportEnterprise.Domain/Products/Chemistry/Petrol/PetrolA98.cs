using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class PetrolA98 : Petrol, IEquatable<PetrolA98>
    {
        public PetrolA98(int id, decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Petrol A98") :
            base(id, weight, chemistryDangers, description)
        {
        }
        protected PetrolA98(int id, decimal weight, string description) :
            base(id, weight, description)
        {
        }
        public bool Equals(PetrolA98 other) => base.Equals(other);
        public override bool Equals(object obj) => obj is PetrolA98 product && Equals(product);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => string.Format("Petrol A98. {0}", base.ToString());
    }
}
