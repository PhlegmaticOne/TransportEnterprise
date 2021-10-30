using TransportEnterprise.Models.Exceptions;
using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    public class Refrigerator : Semitrailer, ITempereratureDependent
    {
        private readonly TemperatureRule _temperatureRule;
        public Refrigerator(decimal maxLoadWeight) : base(maxLoadWeight) { }
        public Refrigerator(decimal maxLoadWeight, TemperatureRule temperatureRule) : this(maxLoadWeight)
        {
            _temperatureRule = temperatureRule;
        }
        public Refrigerator(decimal maxLoadWeight, TemperatureRule temperatureRule, int noiseDb) : this(maxLoadWeight, temperatureRule)
        {
            NoiseLevelInDecibels = noiseDb;
        }

        public TemperatureRule TemperatureRule => _temperatureRule ?? new(-100, 100);
        public int NoiseLevelInDecibels { get; }
        public override void Load(Product product)
        {
            if(product is ITempereratureDependent tempereratureDependent)
            {
                if(tempereratureDependent.TemperatureRule.IsInTheRange(TemperatureRule) == false)
                {
                    throw new TemperatureNotInRangeException("Temperature is not fit", TemperatureRule, tempereratureDependent.TemperatureRule);
                }
            }
            base.Load(product);
        }
    }
}
