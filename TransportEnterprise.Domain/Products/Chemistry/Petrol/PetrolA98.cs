using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    public class PetrolA98 : Petrol
    {
        public PetrolA98(decimal weight, string description) :
            base(weight, description)
        {
        }

        public PetrolA98(decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Petrol A98") :
            base(weight, chemistryDangers, description)
        {
        }
    }
}
