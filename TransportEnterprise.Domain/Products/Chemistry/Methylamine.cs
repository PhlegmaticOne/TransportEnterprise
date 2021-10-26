using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    public class Methylamine : Chemistry, ITempereratureDependent
    {
        public Methylamine(int id, decimal weight, ICollection<ChemistryDanger> chemistryDangers, string description = "Methylamine") :
                           base(id, weight, chemistryDangers, description) { }

        public TemperatureRule GetTemperatureRule() => new(-90, 8);
    }
}
