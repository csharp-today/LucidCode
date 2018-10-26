using System.Collections.Generic;
using System.Linq;

namespace LucidCode
{
    public static class Extensions
    {
        /// <summary>
        /// Returns true if item is in collection array
        /// </summary>
        public static bool In<T>(this T item, params T[] collection) => collection.Contains(item);

        /// <summary>
        /// Returns true if item is in collection array
        /// </summary>
        public static bool In<T>(this T item, IEnumerable<T> collection) => collection.Contains(item);

        /// <summary>
        /// Returns true if item is not null
        /// </summary>
        public static bool IsNotNull<T>(this T item) where T : class => !item.IsNull();

        /// <summary>
        /// Returns true if item is null
        /// </summary>
        public static bool IsNull<T>(this T item) where T : class => item is null;

        /// <summary>
        /// Returns true if item is not in collection array
        /// </summary>
        public static bool NotIn<T>(this T item, params T[] collection) => !item.In(collection);

        /// <summary>
        /// Returns true if item is not in collection array
        /// </summary>
        public static bool NotIn<T>(this T item, IEnumerable<T> collection) => !item.In(collection);
    }
}
