using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TransportEnterprise.Models.Exceptions;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents base instance of semitrailers
    /// </summary>
    public abstract class Semitrailer : IWithLoadingRules
    {
        /// <summary>
        /// Rules for adding new products
        /// </summary>
        protected readonly LoadingRules _rules;
        /// <summary>
        /// Current collection of products in semitrailer
        /// </summary>
        private readonly ICollection<Product> _products;
        /// <summary>
        /// Initializes new semitrailer instance with specified max load capacity and max load value
        /// </summary>
        protected Semitrailer(decimal maxLoadWeight, decimal maxLoadValue)
        {
            LoadCapacity = maxLoadWeight > 0 ? maxLoadWeight :
                throw new WeightException("Load mass capacity cannot be less or equal to zero", 0, maxLoadWeight);
            ValueCapacity = maxLoadValue > 0 ? maxLoadValue :
                throw new WeightException("Load value capacity cannot be less or equal to zero", 0, maxLoadWeight);
            _products = new List<Product>();
            _rules = new LoadingRules(new List<Func<Product, bool>>()
            {
                (product) => product is not null,
                (product) => product.Weight + CurrentLoading <= LoadCapacity,
                (product) => product.Value + CurrentLoadedValue<= ValueCapacity
            });
        }
        /// <summary>
        /// Load capacity of semitrailer
        /// </summary>
        public decimal LoadCapacity { get; init; }
        /// <summary>
        /// Max value capacity
        /// </summary>
        public decimal ValueCapacity { get; init; }
        /// <summary>
        /// Current loading of semitrailer
        /// </summary>
        public decimal CurrentLoading { get; protected set; }
        /// <summary>
        /// Current loaded value
        /// </summary>
        public decimal CurrentLoadedValue { get; protected set; }
        /// <summary>
        /// Loaded ro semitrialer products
        /// </summary>
        public IReadOnlyCollection<Product> Products => new ReadOnlyCollection<Product>(_products.ToList());
        /// <summary>
        /// Loads new product to semitrailer
        /// </summary>
        public virtual void Load(Product product)
        {
            if (GetLoadingRules().CanLoad(product) == false)
            {
                throw new ArgumentException("Wrong product", nameof(product));
            }
            CurrentLoadedValue += product.Value;
            CurrentLoading += product.Weight;
            _products.Add(product);
        }
        /// <summary>
        /// Unloads product from semitrailer
        /// </summary>
        public virtual void Unload(Product product)
        {
            if (Products.Contains(product))
            {
                CurrentLoading -= product.Weight;
                _products.Remove(product);
            }
        }
        /// <summary>
        /// Unloads all products from semitriler
        /// </summary>
        public void UnloadAll() => _products.Clear();
        /// <summary>
        /// Checks equality of current semitriler with specified object
        /// </summary>
        public override bool Equals(object obj) => obj is Semitrailer semitrailer &&
                                                   semitrailer.GetType() == GetType() &&
                                                   semitrailer.LoadCapacity == LoadCapacity &&
                                                   _products.AllEquals(semitrailer._products);
        /// <summary>
        /// Gets hash code of current semitrailer
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => (int)LoadCapacity;
        /// <summary>
        /// Gets string representation of current semitrailer
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Format("{0}. Max load capacity: {1:f4}. Current loading: {2:f4}", GetType().Name, LoadCapacity, CurrentLoading);
        /// <summary>
        /// Gets rules for adding new product to the semitrailer
        /// </summary>
        /// <returns></returns>
        public LoadingRules GetLoadingRules() => _rules;
    }
}