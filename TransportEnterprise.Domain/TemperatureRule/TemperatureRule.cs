namespace TransportEnterprise.Models
{
    public class TemperatureRule
    {
        public TemperatureRule(int minimalTemperature, int maximumTemperature) => (MinimalTemperature, MaximumTemperature)
                                                                                = (minimalTemperature, maximumTemperature);
        public int MinimalTemperature { get; init; }
        public int MaximumTemperature { get; init; }
    }
}