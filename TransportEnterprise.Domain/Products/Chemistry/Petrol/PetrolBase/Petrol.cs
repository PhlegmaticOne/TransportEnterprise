using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    [Serializable]
    public abstract class Petrol : Chemistry
    {
        public Petrol(int id, decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Petrol") :
            base(id, weight, chemistryDangers, description)
        { }
        protected Petrol(int id, decimal weight, string description) :
            base(id, weight, description) { }
    }
}
