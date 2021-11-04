using System;
using System.Collections.Generic;
using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents methylamine instance
    /// </summary>
    public class Methylamine : Chemistry, ITempereratureDependent, IEquatable<Methylamine>
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
                           base(weight, value, chemistryDangers, description) => 
                           _temperatureRule = temperatureRule;
        /// <summary>
        /// Temperature rule of current methylamine instance
        /// </summary>
        public TemperatureRule TemperatureRule => _temperatureRule ?? new TemperatureRule(-90, 10);
        /// <summary>
        /// Checks equality of two methylamines
        /// </summary>
        public bool Equals(Methylamine other) => other.TemperatureRule == TemperatureRule && base.Equals(other);
        /// <summary>
        /// Check equality of methylamine with specified object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) => Equals(obj as Methylamine);
        /// <summary>
        /// Gets hash code of methylamine
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => base.GetHashCode();
    }
}
