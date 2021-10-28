using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    public class Refrigerator : Semitrailer, ITempereratureDependent
    {
        public Refrigerator(decimal maxLoadWeight) : base(maxLoadWeight) { }

        public TemperatureRule TemperatureRule => new(-100, 100); 
    }
}
