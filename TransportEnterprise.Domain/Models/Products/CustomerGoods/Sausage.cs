using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    public class Sausage : CustomerGood, ITempereratureDependent
    {
        public Sausage(decimal weight, decimal value, string description, SausageType sausageType, TemperatureRule temperatureRule) : base(weight, value, description)
        {
            SausageType = sausageType;
            TemperatureRule = temperatureRule ?? new TemperatureRule(-2, 15);
        }
        public SausageType SausageType { get; private set; }
        public TemperatureRule TemperatureRule { get; }
    }
    public enum SausageType
    {
        Cow,
        Pork,
        Chicken,
        Soy
    }
}
