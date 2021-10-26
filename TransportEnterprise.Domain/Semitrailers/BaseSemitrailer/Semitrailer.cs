using System;
using System.Collections.Generic;
using TransportEnterprise.Core.Exceptions;

namespace TransportEnterprise.Models
{
    public abstract class Semitrailer<T> where T : Product
    {
        public Semitrailer(decimal maxLoadWeight)
        {
            LoadCapacity = maxLoadWeight > 0 ? maxLoadWeight : throw new WeightException("Load capacity cannot be less or equal to zero", maxLoadWeight);
            Products = new List<T>();
        }
        public decimal LoadCapacity { get; init; }
        public decimal CurrentLoading { get; protected set; }
        protected ICollection<T> Products { get; set; }
        public virtual void Load(T product)
        {
            if (product is null) throw new ArgumentNullException(nameof(product), "Product cannot be null");
            CurrentLoading = (CurrentLoading + product.Weight > LoadCapacity) ?
                             CurrentLoading += product.Weight :
                             throw new SemitrailerOverloadingException("Semitrailer is overloaded", LoadCapacity, CurrentLoading + product.Weight);
            Products.Add(product);
        }
        public virtual void Unload(T product)
        {
            CurrentLoading -= product.Weight;
            Products.Remove(product);
        }
    }
}