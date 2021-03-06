using System;
using TransportEnterprise.Models.Interfaces;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents sausage type
    /// </summary>
    public class Sausage : CustomerGood, ITempereratureDependent, IEquatable<Sausage>
    {
        /// <summary>
        /// Initializes new sausage type
        /// </summary>
        /// <param name="weight">Specified weight</param>
        /// <param name="value">Specified value</param>
        /// <param name="description">Specified description</param>
        /// <param name="sausageType">Specified sausage type</param>
        /// <param name="temperatureRule">Specified temperature rule</param>
        public Sausage(decimal weight, decimal value, string description,
                       SausageType sausageType, TemperatureRule temperatureRule) :
                       base(weight, value, description)
        {
            SausageType = sausageType;
            TemperatureRule = temperatureRule ?? new TemperatureRule(-2, 15);
        }
        /// <summary>
        /// Sausage type
        /// </summary>
        public SausageType SausageType { get; }
        /// <summary>
        /// Temperature rule
        /// </summary>
        public TemperatureRule TemperatureRule { get; }
        /// <summary>
        /// Checks equality of two sausages
        /// </summary>
        public bool Equals(Sausage other) => TemperatureRule == other.TemperatureRule && SausageType == other.SausageType && base.Equals(other);
        /// <summary>
        /// Checks equality of current sausage with specified object
        /// </summary>
        public override bool Equals(object obj) => Equals(obj as Sausage);
        /// <summary>
        /// Gets hash code of sausage
        /// </summary>
        public override int GetHashCode() => base.GetHashCode();
        /// <summary>
        /// Gets string representation of sausage
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Format("{0}. {1}", SausageType, base.ToString());
    }
    /// <summary>
    /// Represents sausage consist type
    /// </summary>
    public enum SausageType
    {
        Cow,
        Pork,
        Chicken,
        Soy
    }
}
