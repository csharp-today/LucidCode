using System.Linq;

namespace LucidCode
{
    public static class Extensions
    {
        public static bool In<T>(this T item, params T[] collection) => collection.Contains(item);
        public static bool NotIn<T>(this T item, params T[] collection) => !item.In(collection);
    }
}
