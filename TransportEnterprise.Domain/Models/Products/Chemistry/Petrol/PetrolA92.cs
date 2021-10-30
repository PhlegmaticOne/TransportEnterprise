using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    public class PetrolA92 : Petrol
    {
        public PetrolA92() { }
        public PetrolA92(decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description) :
            base(weight, chemistryDangers, description)
        {
        }
        protected PetrolA92(decimal weight, string description = "Petrol A92") :
            base(weight, description)
        {
        }
    }
}
