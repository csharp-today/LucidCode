using System;
using System.Collections.Generic;
using System.Linq;

namespace LucidCode
{
    /// <summary>
    /// LucidCode extensions designed to improve code readability
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Returns true if object is in collection
        /// </summary>
        public static bool In<T>(this T item, params T[] collection) => collection.Contains(item);

        /// <summary>
        /// Returns true if object is in collection
        /// </summary>
        public static bool In<T>(this T item, IEnumerable<T> collection) => collection.Contains(item);

        /// <summary>
        /// Returns true if object is not null
        /// </summary>
        public static bool IsNotNull<T>(this T item) where T : class => !item.IsNull();

        /// <summary>
        /// Returns true if object is not null
        /// </summary>
        public static bool IsNotNull<T>(this T? item) where T : struct => !item.IsNull();

        /// <summary>
        /// Returns true if object is null
        /// </summary>
        public static bool IsNull<T>(this T item) where T : class => item is null;

        /// <summary>
        /// Returns true if object is null
        /// </summary>
        public static bool IsNull<T>(this T? item) where T : struct => item is null;

        /// <summary>
        /// Returns true if object is not in collection
        /// </summary>
        public static bool NotIn<T>(this T item, params T[] collection) => !item.In(collection);

        /// <summary>
        /// Returns true if object is not in collection
        /// </summary>
        public static bool NotIn<T>(this T item, IEnumerable<T> collection) => !item.In(collection);

        /// <summary>
        /// Execute action on an item and return the item
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="item">Item</param>
        /// <param name="action">Set action for the item</param>
        /// <returns>The same item</returns>
        public static T Set<T>(this T item, Action<T> action)
        {
            action(item);
            return item;
        }

        /// <summary>
        /// Returns null if string is empty, otherwise the string value
        /// </summary>
        public static string ToNullIfEmpty(this string value) => string.IsNullOrEmpty(value) ? null : value;

        /// <summary>
        /// Returns null if string is white space, otherwise the string value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToNullIfWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value) ? null : value;
    }
}
