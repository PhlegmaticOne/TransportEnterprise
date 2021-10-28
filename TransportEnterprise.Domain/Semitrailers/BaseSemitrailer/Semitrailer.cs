using System;
using System.Collections.Generic;
using System.Linq;
using TransportEnterprise.Models.Exceptions;
using TransportEnterprise.Models.Extensions;

namespace TransportEnterprise.Models
{
    public abstract class Semitrailer : IEquatable<Semitrailer>
    {
        public Semitrailer(decimal maxLoadWeight)
        {
            LoadCapacity = maxLoadWeight > 0 ? maxLoadWeight : throw new WeightException("Load capacity cannot be less or equal to zero", maxLoadWeight);
            Products = new List<Product>();
        }
        public decimal LoadCapacity { get; init; }
        public decimal CurrentLoading { get; protected set; }
        public ICollection<Product> Products { get; set; }
        protected Type ProductType;
        public virtual void Load(Product product)
        {
            if (product is null) throw new ArgumentNullException(nameof(product), "Product cannot be null");
            if(Products.Any())
            {
                if(product.GetType() != ProductType)
                {
                    throw new WrongObjectTypeLoadingException("Wrong income object", ProductType, product.GetType());
                }
            }
            else
            {
                ProductType = product.GetType();
            }
            var additional = CurrentLoading + product.Weight;
            if(additional <= LoadCapacity)
            {
                CurrentLoading += additional;
            }
            else
            {
                throw new SemitrailerOverloadingException("Semitrailer is overloaded", LoadCapacity, additional);
            }
            Products.Add(product);
        }
        public void Unload(Product product)
        {
            if (Products.Contains(product))
            {
                CurrentLoading -= product.Weight;
                Products.Remove(product);
            }
        }
        public bool Equals(Semitrailer other) => other.LoadCapacity == LoadCapacity && Products.AllEquals(other.Products);
        public override bool Equals(object obj) => obj is Semitrailer semitrailer && Equals(semitrailer);
        public override int GetHashCode() => (int)LoadCapacity;
        public override string ToString() => string.Format("{0}. Max load capacity: {1:f4}. Current loading: {2:f4}", GetType().Name, LoadCapacity, CurrentLoading);
    }
}