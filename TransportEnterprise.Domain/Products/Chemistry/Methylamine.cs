using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    public class Methylamine : Chemistry, ITempereratureDependent, IEquatable<Methylamine>
    {
        public Methylamine(int id, decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Methylamine") :
                           base(id, weight, chemistryDangers, description) { }

        public TemperatureRule GetTemperatureRule() => new(-90, 8);
        public bool Equals(Methylamine other) => base.Equals(other);
        public override bool Equals(object obj) => obj is Methylamine product && Equals(product);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => string.Format("Methylamine. {0}", base.ToString());
    }
}
