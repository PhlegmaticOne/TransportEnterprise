using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class PetrolA92 : Petrol
    {
        public PetrolA92(int id, decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description) :
            base(id, weight, chemistryDangers, description)
        {
        }
        protected PetrolA92(int id, decimal weight, string description = "Petrol A92") :
            base(id, weight, description)
        {
        }

        
    }
}
