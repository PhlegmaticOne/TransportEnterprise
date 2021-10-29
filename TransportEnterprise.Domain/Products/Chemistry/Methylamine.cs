using System.Collections.Generic;
using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    public class Methylamine : Chemistry, ITempereratureDependent
    {
        private readonly TemperatureRule _temperatureRule;
        public Methylamine(decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Methylamine") :
                           base(weight, chemistryDangers, description) { }

        public Methylamine(decimal weight, ICollection<ChemistryDanger> chemistryDangers, TemperatureRule temperatureRule, string description = "Methylamine") :
                           base(weight, chemistryDangers, description)
        {
            _temperatureRule = temperatureRule;
        }

        public TemperatureRule TemperatureRule => _temperatureRule ?? new TemperatureRule(-90, 10);
    }
}
