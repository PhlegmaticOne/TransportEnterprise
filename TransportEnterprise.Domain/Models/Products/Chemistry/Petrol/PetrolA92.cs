using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents petrol A92 instance
    /// </summary>
    public class PetrolA92 : Petrol
    {
        /// <summary>
        /// Initialzes new PetrolA92 instance
        /// </summary>
        public PetrolA92(decimal weight, decimal value, ICollection<ChemistryDanger> chemistryDangers, string description) :
            base(weight, value, chemistryDangers, description)
        {
        }
    }
}
