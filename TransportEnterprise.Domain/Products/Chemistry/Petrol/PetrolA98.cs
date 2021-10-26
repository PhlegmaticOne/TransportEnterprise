using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class PetrolA98 : Petrol
    {
        public PetrolA98(int id, decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Petrol A98") :
            base(id, weight, chemistryDangers, description)
        {
        }
        protected PetrolA98(int id, decimal weight, string description) :
            base(id, weight, description)
        {
        }
    }
}
