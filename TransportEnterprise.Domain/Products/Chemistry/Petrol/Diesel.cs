using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    [Serializable]
    public class Diesel : Petrol
    {
        public Diesel(int id, decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Diesel petrol")
            : base(id, weight, chemistryDangers, description)
        {
        }
        protected Diesel(int id, decimal weight, string description) :
            base(id, weight, description)
        {
        }
    }
}
