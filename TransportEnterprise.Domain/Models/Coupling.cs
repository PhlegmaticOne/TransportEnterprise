using System;
using System.Collections.Generic;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents coupling of truck tractor and semitrailer
    /// </summary>
    public class Coupling : IEquatable<Coupling>
    {
        /// <summary>
        /// Semitrailer
        /// </summary>
        public Semitrailer Semitrailer { get; }
        /// <summary>
        /// Truck tractor
        /// </summary>
        public TruckTractor TruckTractor { get; }
        /// <summary>
        /// Initializes new coupling instance with specified semitrailer and truck tractor
        /// </summary>
        /// <param name="semitrailer"></param>
        /// <param name="truckTractor"></param>
        public Coupling(Semitrailer semitrailer, TruckTractor truckTractor)
        {
            Semitrailer = semitrailer ?? throw new ArgumentNullException(nameof(semitrailer));
            TruckTractor = truckTractor ?? throw new ArgumentNullException(nameof(truckTractor));
            if(TruckTractor.Semitrailer is null)
            {
                TruckTractor.HookUp(semitrailer);
            }
        }
        /// <summary>
        /// Products in coupling
        /// </summary>
        public IReadOnlyCollection<Product> Products => Semitrailer.Products;
        /// <summary>
        /// Loads new product to coupling
        /// </summary>
        /// <param name="product"></param>
        public void Load(Product product) => Semitrailer.Load(product);
        /// <summary>
        /// Unloads product from the coupling
        /// </summary>
        /// <param name="product"></param>
        public void Unload(Product product) => Semitrailer.Unload(product);
        /// <summary>
        /// Unloads all products from the coupling
        /// </summary>
        public void UnloadAll() => Semitrailer.UnloadAll();
        /// <summary>
        /// Checks equality of current coupling with other specified object
        /// </summary>
        public override bool Equals(object obj) => obj is Coupling coupling && Equals(coupling);
        /// <summary>
        /// Checks equality of current coupling with other coupling
        /// </summary>
        public bool Equals(Coupling other) => other.Semitrailer.Equals(Semitrailer) && other.TruckTractor.Equals(TruckTractor);
        /// <summary>
        /// Gets hash code of current coupling instance
        /// </summary>
        public override int GetHashCode() => Semitrailer.GetHashCode() + TruckTractor.GetHashCode();
        /// <summary>
        /// Gets string representation of current coupling instance
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Format("{0}. {1}", Semitrailer, TruckTractor);
    }
}
