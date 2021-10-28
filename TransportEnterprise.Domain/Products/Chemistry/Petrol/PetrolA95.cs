using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    public class PetrolA95 : Petrol
    {
        public PetrolA95(decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Petrol A95") :
            base(weight, chemistryDangers, description)
        { }
        protected PetrolA95(decimal weight, string description) :
            base(weight, description) { }
    }
}