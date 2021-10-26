using System;
using TransportEnterprise.Core.Exceptions;

namespace TransportEnterprise.Models
{
    [Serializable]
    public abstract class Product : BaseDomainModel, IEquatable<Product>
    {
        public Product(int id, decimal weight, string description)
        {
            Weight = weight >= 0 ? weight : throw new WeightException("Weight cannot be less or equal to zero", weight);
            Description = description;
            Id = id;
        }
        public decimal Weight { get; }
        public string Description { get; set; }

        public bool Equals(Product other) => Weight == other.Weight && Description == other.Description;
        public override bool Equals(object obj) => obj is Product product && Equals(product);
        public override int GetHashCode() => (int)(Weight + Description.GetHashCode());
        public override string ToString() => string.Format("{0}. Weight: {1:f4}", Description, Weight);
    }
}