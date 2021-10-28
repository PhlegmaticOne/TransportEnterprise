using System.Collections.Generic;
using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    public class Methylamine : Chemistry, ITempereratureDependent
    {
        public Methylamine(decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Methylamine") :
                           base(weight, chemistryDangers, description) { }

        public Methylamine(decimal weight, ICollection<ChemistryDanger> chemistryDangers, TemperatureRule temperatureRule, string description = "Methylamine") :
                           base(weight, chemistryDangers, description)
        {
            TemperatureRule = temperatureRule;
        }

        public TemperatureRule TemperatureRule { get; }
    }
}
