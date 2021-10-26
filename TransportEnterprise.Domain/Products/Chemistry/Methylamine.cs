using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    public class Methylamine : Chemistry, ITempereratureDependent
    {
        public Methylamine(decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Methylamine") :
                           base(weight, chemistryDangers, description) { }

        public TemperatureRule TemperatureRule { get; }
    }
}
