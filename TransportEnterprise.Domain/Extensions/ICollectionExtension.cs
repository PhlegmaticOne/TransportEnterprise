using System;
using System.Collections.Generic;
using System.Linq;

namespace TransportEnterprise.Models
{
    public static class ICollectionExtension
    {
        public static bool AllEquals<T>(this ICollection<T> collection, Func<T, int, bool> predicate) where T : BaseDomainModel
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if(predicate.Invoke(collection.ElementAt(i), i) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
