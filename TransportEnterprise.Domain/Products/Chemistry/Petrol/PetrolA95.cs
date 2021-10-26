using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class PetrolA95 : Petrol
    {
        public PetrolA95(int id, decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Petrol A95") :
            base(id, weight, chemistryDangers, description)
        { }
        protected PetrolA95(int id, decimal weight, string description) :
            base(id, weight, description) { }
    }
}