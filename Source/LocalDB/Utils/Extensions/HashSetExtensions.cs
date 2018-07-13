using System.Collections.Generic;

namespace LocalDB.Utils.Extensions
{
    public static class HashSetExtensions
    {
        public static HashSet<T> AddRange<T>(this HashSet<T> hashSet, IEnumerable<T> items)
        {
            if (items == null) return hashSet;

            foreach (var item in items)
            {
                hashSet.Add(item);
            }

            return hashSet;
        }
    }
}
