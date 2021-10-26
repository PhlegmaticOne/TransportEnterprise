using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    public abstract class Chemistry : Product
    {
        protected Chemistry(decimal weight, string description) :
                            base(weight, description) { }
        public Chemistry(decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description) :
                        this(weight, description) => ChemistryDangers = chemistryDangers;
        public ICollection<ChemistryDanger> ChemistryDangers { get; }
    }
}
