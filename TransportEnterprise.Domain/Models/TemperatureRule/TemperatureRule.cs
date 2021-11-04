using System;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents temperature rule instance
    /// </summary>
    public class TemperatureRule : IEquatable<TemperatureRule>
    {
        /// <summary>
        /// Initializes new temperature rule instance with specified max and min temperature
        /// </summary>
        public TemperatureRule(double minimalTemperature, double maximumTemperature) => (MinimalTemperature, MaximumTemperature)
                                                                                = (minimalTemperature, maximumTemperature);
        /// <summary>
        /// Minimal temperature
        /// </summary>
        public double MinimalTemperature { get; init; }
        /// <summary>
        /// Maximum temperature
        /// </summary>
        public double MaximumTemperature { get; init; }
        /// <summary>
        /// Checks if current temperature rule is in the range of income temperature rule
        /// </summary>
        /// <param name="temperatureRule"></param>
        public bool IsInTheRange(TemperatureRule temperatureRule) => MinimalTemperature >= temperatureRule.MinimalTemperature &&
                                                                     MaximumTemperature <= temperatureRule.MaximumTemperature;
        /// <summary>
        /// Overloading == operator for temperature rule
        /// </summary>
        public static bool operator ==(TemperatureRule a, TemperatureRule b) => a.Equals(b);
        /// <summary>
        /// Overloading != operator for temperature rule
        /// </summary>
        public static bool operator !=(TemperatureRule a, TemperatureRule b) => !(a == b);
        /// <summary>
        /// Checks equality of current temperature rule with other temperatur erule
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(TemperatureRule other) => MinimalTemperature == other.MinimalTemperature && MaximumTemperature == other.MaximumTemperature;
        /// <summary>
        /// Checks equality of current temperature rule with other specified object
        /// </summary>
        public override bool Equals(object obj) => obj is TemperatureRule temperatureRule && Equals(temperatureRule);
        /// <summary>
        /// Gets hash code of current temperature rule instance
        /// </summary>
        public override int GetHashCode() => (int)(MinimalTemperature * MaximumTemperature);
        /// <summary>
        /// Gets string representation of current temperature rule instance
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Format("[{0:f2}; {1:f2}]", MinimalTemperature, MaximumTemperature);
    }
}