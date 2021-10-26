using System;
using TransportEnterprise.Core.Exceptions;

namespace TransportEnterprise.Models
{
    [Serializable]
    public abstract class Product : BaseDomainModel
    {
        public Product(int id, decimal weight, string description)
        {
            Weight = weight >= 0 ? weight : throw new WeightException("Weight cannot be less or equal to zero", weight);
            Description = description;
            Id = id;
        }
        public decimal Weight { get; }
        public string Description { get; set; }
    }
}