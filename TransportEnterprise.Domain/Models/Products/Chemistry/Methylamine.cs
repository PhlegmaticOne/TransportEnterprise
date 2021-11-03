using System.Collections.Generic;
using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents methylamine instance
    /// </summary>
    public class Methylamine : Chemistry, ITempereratureDependent
    {
        private readonly TemperatureRule _temperatureRule;
        /// <summary>
        /// Initializes new methylamine instance
        /// </summary>
        /// <param name="weight">Specified weight</param>
        /// <param name="chemistryDangers">Specified dangers</param>
        /// <param name="temperatureRule">Specified temperature rule</param>
        /// <param name="description">Specified description</param>
        public Methylamine(decimal weight, decimal value, ICollection<ChemistryDanger> chemistryDangers, TemperatureRule temperatureRule, string description = "Methylamine") :
                           base(weight, value, chemistryDangers, description)
        {
            _temperatureRule = temperatureRule;
        }
        /// <summary>
        /// Temperature rule of current methylamine instance
        /// </summary>
        public TemperatureRule TemperatureRule => _temperatureRule ?? new TemperatureRule(-90, 10);
    }
}
