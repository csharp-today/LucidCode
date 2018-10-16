using System.Collections.Generic;
using System.Linq;

namespace LucidCode
{
    public static class Extensions
    {
        public static bool In<T>(this T item, params T[] collection) => collection.Contains(item);
        public static bool InCollection<T>(this T item, IEnumerable<T> collection) => collection.Contains(item);
        public static bool NotIn<T>(this T item, params T[] collection) => !item.In(collection);
        public static bool NotInCollection<T>(this T item, IEnumerable<T> collection) => !item.InCollection(collection);
    }
}
