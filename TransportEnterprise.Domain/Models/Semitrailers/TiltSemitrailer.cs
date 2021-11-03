using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents tilt semitrailer
    /// </summary>
    public class TiltSemitrailer : Semitrailer
    {
        private readonly Dictionary<Type, ICollection<Product>> _sortedProducts;
        /// <summary>
        /// Initializes new titl semitrailer insctance with specified max laod capacity 
        /// </summary>
        public TiltSemitrailer(decimal maxLoadWeight, decimal maxValueCapacity) : base(maxLoadWeight, maxValueCapacity)
        {
            _sortedProducts = new();
        }
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
        public ICollection<Product> GetProductsByType(Type productType)
        {
            _sortedProducts.TryGetValue(productType, out ICollection<Product> products);
            return products;
        }
    }
}
