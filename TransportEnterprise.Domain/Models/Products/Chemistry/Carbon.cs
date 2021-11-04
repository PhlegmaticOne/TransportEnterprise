using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    public class Carbon : Chemistry
    {
        public Carbon(decimal weight, decimal value, ICollection<ChemistryDanger> chemistryDangers, string description) : base(weight, value, chemistryDangers, description)
        {
        }
    }
}
