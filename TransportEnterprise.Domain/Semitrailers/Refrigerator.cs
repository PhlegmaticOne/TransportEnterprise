using System;
using TransportEnterprise.Models.Exceptions;
using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    public class Refrigerator : Semitrailer, ITempereratureDependent
    {
        public Refrigerator(decimal maxLoadWeight) : base(maxLoadWeight) { }

        public TemperatureRule TemperatureRule => new(-100, 100);
        public override void Load(Product product)
        {
            if(product is ITempereratureDependent tempereratureDependent)
            {
                if(TemperatureRule.IsInTheRange(tempereratureDependent.TemperatureRule) == false)
                {
                    throw new TemperatureNotInRangeException("Temperature is not fit", TemperatureRule, tempereratureDependent.TemperatureRule);
                }
            }
            base.Load(product);
        }
    }
}
