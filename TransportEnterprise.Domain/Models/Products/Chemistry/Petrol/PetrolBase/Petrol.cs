using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents base instance of petrol
    /// </summary>
    public abstract class Petrol : Chemistry
    {
        /// <summary>
        /// Initializes new petrol instance
        /// </summary>
        /// <param name="weight">Specified weight</param>
        /// <param name="chemistryDangers">Chemisty dangers</param>
        /// <param name="description">Description</param>
        public Petrol(decimal weight, decimal value, ICollection<ChemistryDanger> chemistryDangers, string description) :
            base (weight, value, chemistryDangers, description) { }
    }
}
