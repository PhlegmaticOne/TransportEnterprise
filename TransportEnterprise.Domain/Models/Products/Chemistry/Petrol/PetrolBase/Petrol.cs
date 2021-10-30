using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    public abstract class Petrol : Chemistry
    {
        public Petrol() { }
        public Petrol(decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Petrol") :
            base (weight, chemistryDangers, description)
        { }
        protected Petrol(decimal weight, string description) :
            base(weight, description) { }
    }
}
