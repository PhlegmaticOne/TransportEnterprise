using TransportEnterprise.Core.Exceptions;

namespace TransportEnterprise.Models
{
    public abstract class Product
    {
        public Product(decimal weight, string description)
        {
            Weight = weight >= 0 ? weight : throw new WeightException("Weight cannot be less or equal to zero", weight);
            Description = description;
        }
        public decimal Weight { get; }
        public string Description { get; set; }
    }
}