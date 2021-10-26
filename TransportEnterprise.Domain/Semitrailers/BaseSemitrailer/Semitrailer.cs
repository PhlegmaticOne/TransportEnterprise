using System;
using System.Collections.Generic;
using System.Linq;
using TransportEnterprise.Core.Exceptions;

namespace TransportEnterprise.Models
{
    [Serializable]
    public abstract class Semitrailer<T> : BaseDomainModel, IEquatable<Semitrailer<T>> where T : Product
    {
        public Semitrailer(int id, decimal maxLoadWeight)
        {
            LoadCapacity = maxLoadWeight > 0 ? maxLoadWeight : throw new WeightException("Load capacity cannot be less or equal to zero", maxLoadWeight);
            Products = new List<T>();
            Id = id;
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
        public bool Equals(Semitrailer<T> other) => other.LoadCapacity == LoadCapacity && Products.AllEquals((p, i) => p.Equals(other.Products.ElementAt(i)));
        public override bool Equals(object obj) => obj is Semitrailer<T> semitrailer && Equals(semitrailer);
        public override int GetHashCode() => (int)LoadCapacity;
        public override string ToString() => string.Format("Max load capacity: {0:f4}. Current loading: {1:f4}", LoadCapacity, CurrentLoading);
    }
}