using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents diesel instance
    /// </summary>
    public class Diesel : Petrol
    {
        /// <summary>
        /// Initializes new diesel instance
        /// </summary>
        public Diesel(decimal weight, decimal value, ICollection<ChemistryDanger> chemistryDangers, string description)
            : base(weight, value, chemistryDangers, description)
        {
        }
    }
}
