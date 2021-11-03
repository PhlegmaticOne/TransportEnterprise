using System;
using TransportEnterprise.Models.Exceptions;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents base product instance
    /// </summary>
    public abstract class Product : IEquatable<Product>
    {
        /// <summary>
        /// Initializes new product instance with specified weight and desctription
        /// </summary>
        protected Product(decimal weight, decimal value, string description)
        {
            Weight = weight >= 0 ? weight : throw new WeightException("Weight cannot be less or equal to zero", weight);
            Value = value >= 0 ? value : throw new ArgumentException("Value cannot be less or equal to zero", nameof(value));
            Description = description;
        }
        /// <summary>
        /// Weight of product 
        /// </summary>
        public decimal Weight { get; }
        /// <summary>
        /// Value of product
        /// </summary>
        public decimal Value { get; }
        /// <summary>
        /// Sescription of product
        /// </summary>
        public string Description { get; }
        /// <summary>
        /// Checks equality of two products
        /// </summary>
        public bool Equals(Product other) => Weight == other.Weight && Description == other.Description;
        /// <summary>
        /// Gets hash code of product
        /// </summary>
        public override int GetHashCode() => (int)(Weight + Description.GetHashCode());
        /// <summary>
        /// Gets string representaton of product
        /// </summary>
        public override string ToString() => string.Format("{0}. {1}. Weight: {2:f4}", GetType().Name, Description, Weight);

        public override bool Equals(object obj) => Equals(obj as Product);
    }
}