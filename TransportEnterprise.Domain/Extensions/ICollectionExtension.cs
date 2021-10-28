using System;
using System.Collections.Generic;
using System.Linq;

namespace TransportEnterprise.Models.Extensions
{
    public static class ICollectionExtension
    {
        public static bool AllEquals<T>(this ICollection<T> collection, Func<T, int, bool> predicate)
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
        public static bool AllEquals<T>(this ICollection<T> collection, ICollection<T> other)
        {
            foreach (var entity in collection)
            {
                if(other.Contains(entity) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
