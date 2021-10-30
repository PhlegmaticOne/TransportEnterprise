using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    public class Milk : CustomerGood, ITempereratureDependent
    {
        private readonly TemperatureRule _temperatureRule;
        public Milk(decimal weight, string description) : base(weight, description)
        {
        }

        public Milk(decimal weight, string description, TemperatureRule temperatureRule) : base(weight, description)
        {
            _temperatureRule = temperatureRule;
        }

        public TemperatureRule TemperatureRule => _temperatureRule ?? new(-10, 0);
    }
}
