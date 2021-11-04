using System;
using System.Collections.Generic;
using System.Linq;

namespace TransportEnterprise.Models
{
    /// <summary>
    /// Represents instance for rules that must implement each of semitrailer
    /// </summary>
    public sealed class LoadingRules
    {
        /// <summary>
        /// Rules for adding products
        /// </summary>
        private readonly List<Func<Product, bool>> _rules;
        /// <summary>
        /// Initializes new LoadingRules instance with specified collection of rules
        /// </summary>
        /// <param name="rules"></param>
        public LoadingRules(IEnumerable<Func<Product, bool>> rules) => 
                                                            _rules = rules.ToList() ??
                                                            throw new ArgumentNullException(nameof(rules));
        /// <summary>
        /// Adds new collection of rules to a current rules
        /// </summary>
        /// <param name="rules"></param>
        public void AddRange(params Func<Product, bool>[] rules) => _rules.AddRange(rules);
        /// <summary>
        /// Checks is specified product can be loaded in semitrailer
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool CanLoad(Product product) => _rules.All(p => p.Invoke(product) == true);
    }
}
