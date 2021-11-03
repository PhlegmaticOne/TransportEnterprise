using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents petrol A98 instance
    /// </summary>
    public class PetrolA98 : Petrol
    {
        /// <summary>
        /// Initializes new Petrol A98 instance
        /// </summary>
        public PetrolA98(decimal weight, decimal value, ICollection<ChemistryDanger> chemistryDangers, string description = "Petrol A98") :
            base(weight, value, chemistryDangers, description)
        {
        }
    }
}
