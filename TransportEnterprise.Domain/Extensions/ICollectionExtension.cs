using System.Collections.Generic;

namespace TransportEnterprise.Models.Extensions
{
    /// <summary>
    /// Extensions for ICollection of type T
    /// </summary>
    public static class ICollectionExtension
    {
        /// <summary>
        /// Checks equality of every object in collection with any object in other collection
        /// </summary>
        public static bool AllEquals<T>(this ICollection<T> collection, ICollection<T> other)
        {
            if(collection.Count != other.Count)
            {
                return false;
            }
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
