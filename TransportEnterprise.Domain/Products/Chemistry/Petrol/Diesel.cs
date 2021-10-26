using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    public class Diesel : Petrol
    {
        public Diesel(decimal weight, string description) :
            base(weight, description)
        {
        }

        public Diesel(decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Diesel petrol")
            : base(weight, chemistryDangers, description)
        {
        }
    }
}
