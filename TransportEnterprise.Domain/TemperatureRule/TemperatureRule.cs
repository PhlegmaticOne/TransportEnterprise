using System;

namespace TransportEnterprise.Models
{
    public class TemperatureRule : IEquatable<TemperatureRule>
    {
        public TemperatureRule(int minimalTemperature, int maximumTemperature) => (MinimalTemperature, MaximumTemperature)
                                                                                = (minimalTemperature, maximumTemperature);
        public int MinimalTemperature { get; init; }
        public int MaximumTemperature { get; init; }
        public TemperatureRule ToKelvins() => new(MinimalTemperature + 273, MaximumTemperature + 273);
        public bool Equals(TemperatureRule other) => MinimalTemperature == other.MinimalTemperature && MaximumTemperature == other.MaximumTemperature;
        public override bool Equals(object obj) => obj is TemperatureRule temperatureRule && Equals(temperatureRule);
        public override int GetHashCode() => MinimalTemperature * MaximumTemperature;
        public override string ToString() => string.Format("[{0}, {1}]", MinimalTemperature, MaximumTemperature);
    }
}