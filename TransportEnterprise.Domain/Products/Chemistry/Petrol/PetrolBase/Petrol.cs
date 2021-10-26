using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    public abstract class Petrol : Chemistry
    {
        protected Petrol(decimal weight, string description) :
            base(weight, description) { }

        protected Petrol(decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Petrol") :
            base(weight, chemistryDangers, description) { }
    }
}
