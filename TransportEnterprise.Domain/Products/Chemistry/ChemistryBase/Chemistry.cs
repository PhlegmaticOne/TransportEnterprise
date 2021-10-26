using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    [Serializable]
    public abstract class Chemistry : Product
    {
        public Chemistry(int id, decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description) :
                        this(id, weight, description) => ChemistryDangers = chemistryDangers;
        protected Chemistry(int id, decimal weight, string description) :
                            base(id, weight, description) { }
        public ICollection<ChemistryDanger> ChemistryDangers { get; }
    }
}
