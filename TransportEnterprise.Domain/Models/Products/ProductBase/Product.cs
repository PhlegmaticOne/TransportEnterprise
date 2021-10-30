using System;
using TransportEnterprise.Models.Exceptions;

namespace TransportEnterprise.Models
{
    public abstract class Product
    {
        public Product() { }
        public Product(decimal weight, string description)
        {
            Weight = weight >= 0 ? weight : throw new WeightException("Weight cannot be less or equal to zero", weight);
            Description = description;
        }
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public override int GetHashCode() => (int)(Weight + Description.GetHashCode());
        public override string ToString() => string.Format("{0}. {1}. Weight: {2:f4}", GetType().Name, Description, Weight);
    }
}