using System;
using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents refrigerator semitrailer
    /// </summary>
    public class Refrigerator : Semitrailer, ITempereratureDependent, IEquatable<Refrigerator>
    {
        private readonly TemperatureRule _temperatureRule;
        /// <summary>
        /// Initializes new refrigerator instance
        /// </summary>
        /// <param name="maxLoadWeight">Max load capacity</param>
        /// <param name="temperatureRule">Temperature terms of refrigerator</param>
        /// <param name="noiseDb">Noise in decibels</param>
        public Refrigerator(decimal maxLoadWeight, decimal maxValueCapacity, TemperatureRule temperatureRule, int noiseDb) :
            base(maxLoadWeight, maxValueCapacity)
        {
            NoiseLevelInDecibels = noiseDb;
            _temperatureRule = temperatureRule;
            _rules.AddRange(
                (product) => product is ITempereratureDependent,
                (product) => (product as ITempereratureDependent).TemperatureRule.IsInTheRange(_temperatureRule)
            );
        }

        public TemperatureRule TemperatureRule => _temperatureRule ?? new(-100, 100);
        public int NoiseLevelInDecibels { get; }

        public bool Equals(Refrigerator other) => TemperatureRule.Equals(other.TemperatureRule) && NoiseLevelInDecibels == other.NoiseLevelInDecibels && base.Equals(other);
        public override bool Equals(object obj) => obj is Refrigerator refrigerator && Equals(refrigerator);
        public override string ToString() => string.Format("{0}. Noise: {1} dB. Temperature rule: {2}",
                                             base.ToString(), NoiseLevelInDecibels, TemperatureRule);

        public override int GetHashCode() => NoiseLevelInDecibels + (int)TemperatureRule.MaximumTemperature + base.GetHashCode();
    }
}
