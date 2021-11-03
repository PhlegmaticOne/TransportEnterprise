using System;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents base instance for cusstomer good products 
    /// </summary>
    public abstract class CustomerGood : Product, IEquatable<CustomerGood>
    {
        /// <summary>
        /// Initializes new customer good instance with specified weight and description
        /// </summary>
        public CustomerGood(decimal weight, decimal value, string description) : base(weight, value, description)
        {
        }
        /// <summary>
        /// Checks equality of two customer good products
        /// </summary>
        public bool Equals(CustomerGood other) => Weight == other.Weight && Description == other.Description;
        /// <summary>
        /// Checks equality of specified object with customer good instance
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) => obj is CustomerGood product && Equals(product);
        /// <summary>
        /// Gets hash code of customer good instance
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => base.GetHashCode();
    }
}
