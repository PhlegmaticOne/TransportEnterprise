using System;
using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents milk instance
    /// </summary>
    public class Milk : CustomerGood, ITempereratureDependent, IEquatable<Milk>
    {
        private readonly TemperatureRule _temperatureRule;
        /// <summary>
        /// Initializes new milk instance
        /// </summary>
        /// <param name="weight">Specidied weight</param>
        /// <param name="description">Description</param>
        /// <param name="temperatureRule">Temperature rule</param>
        /// <param name="milkTaste">Milk taste</param>
        public Milk(decimal weight, decimal value, string description, TemperatureRule temperatureRule, MilkTaste milkTaste) :
            base(weight, value, description)
        {
            _temperatureRule = temperatureRule;
            MilkTaste = milkTaste;
        }
        /// <summary>
        /// Temperature rule for milk
        /// </summary>
        public TemperatureRule TemperatureRule => _temperatureRule ?? new(-10, 0);
        /// <summary>
        /// Milk taste
        /// </summary>
        public MilkTaste MilkTaste { get; }
        /// <summary>
        /// Checks equality of two tilt trailers
        /// </summary>
        public bool Equals(Milk other) => TemperatureRule == other.TemperatureRule &&
                                          MilkTaste == other.MilkTaste && base.Equals(other);
        /// <summary>
        /// Checks equality of current milk with specified object
        /// </summary>
        public override bool Equals(object obj) => obj is Milk tilt && Equals(tilt);
        /// <summary>
        /// Gets hash code of milk
        /// </summary>
        public override int GetHashCode() => base.GetHashCode();
        /// <summary>
        /// Gets strin grepresentation of mlk
        /// </summary>
        public override string ToString() => string.Format("{0}. {1}", MilkTaste, base.ToString());
    }
    /// <summary>
    /// Represents taste of a milk
    /// </summary>
    public enum MilkTaste
    {
        Cow,
        Chocolate,
        Soy
    }
}
