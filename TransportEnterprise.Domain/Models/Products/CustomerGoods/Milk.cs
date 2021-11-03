using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents milk instance
    /// </summary>
    public class Milk : CustomerGood, ITempereratureDependent
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

        public TemperatureRule TemperatureRule => _temperatureRule ?? new(-10, 0);
        public MilkTaste MilkTaste { get; }
        public override string ToString() => string.Format("{0}. {1}", MilkTaste, base.ToString());
    }
    public enum MilkTaste
    {
        Cow,
        Chocolate,
        Soy
    }
}
