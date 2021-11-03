using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents Petrol A95 instance
    /// </summary>
    public class PetrolA95 : Petrol
    {
        /// <summary>
        /// Initializes new Petrol A92 instance
        /// </summary>
        public PetrolA95(decimal weight, decimal value, ICollection<ChemistryDanger> chemistryDangers, string description = "Petrol A95") :
            base(weight, value, chemistryDangers, description)
        { }
    }
}