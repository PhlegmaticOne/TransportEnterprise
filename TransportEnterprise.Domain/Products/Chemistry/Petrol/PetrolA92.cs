using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class PetrolA92 : Petrol, IEquatable<PetrolA92>
    {
        public PetrolA92(int id, decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description) :
            base(id, weight, chemistryDangers, description)
        {
        }
        protected PetrolA92(int id, decimal weight, string description = "Petrol A92") :
            base(id, weight, description)
        {
        }

        public bool Equals(PetrolA92 other) => base.Equals(other);
        public override bool Equals(object obj) => obj is PetrolA92 product && Equals(product);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => string.Format("Petrol A92. {0}", base.ToString());
    }
}
