using System;
using System.Collections.Generic;
using System.Linq;

namespace TransportEnterprise.Models
{
    public class LoadingRules
    {
        private readonly List<Func<Product, bool>> _rules;
        public LoadingRules(IEnumerable<Func<Product, bool>> rules) => 
                                                            _rules = rules.ToList() ??
                                                            throw new ArgumentNullException(nameof(rules));
        public void AddRange(params Func<Product, bool>[] rules) => _rules.AddRange(rules);
        public bool CanLoad(Product product) => _rules.All(p => p.Invoke(product) == true);
    }
}
