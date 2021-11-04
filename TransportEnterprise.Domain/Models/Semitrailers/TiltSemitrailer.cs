using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents tilt semitrailer
    /// </summary>
    public class TiltSemitrailer : Semitrailer, IEquatable<TiltSemitrailer>
    {
        /// <summary>
        /// Products grouped by its types
        /// </summary>
        private readonly Dictionary<Type, ICollection<Product>> _sortedProducts;
        /// <summary>
        /// Initializes new titl semitrailer insctance with specified max laod capacity 
        /// </summary>
        public TiltSemitrailer(decimal maxLoadWeight, decimal maxValueCapacity) : base(maxLoadWeight, maxValueCapacity) =>
            _sortedProducts = new();
        public override void Load(Product product)
        {
            base.Load(product);
            var productType = product.GetType();
            if (_sortedProducts.TryGetValue(productType, out ICollection<Product> products))
            {
                products.Add(product);
            }
            else
            {
                _sortedProducts.Add(productType, new List<Product>() { product });
            }
        }
        /// <summary>
        /// Gets all the products of specified type in tilt semitrailer
        /// </summary>
        public ICollection<Product> GetProductsByType(Type productType)
        {
            _sortedProducts.TryGetValue(productType, out ICollection<Product> products);
            return products;
        }
        /// <summary>
        /// Checks equality of two tilt trailers
        /// </summary>
        public bool Equals(TiltSemitrailer other) => base.Equals(other);
        /// <summary>
        /// Checks equality of current tilt semitrailer with specified object
        /// </summary>
        public override bool Equals(object obj) => obj is TiltSemitrailer tilt && Equals(tilt);
        /// <summary>
        /// Gets hash code of tilt semitrailer
        /// </summary>
        public override int GetHashCode() => base.GetHashCode();
    }
}
