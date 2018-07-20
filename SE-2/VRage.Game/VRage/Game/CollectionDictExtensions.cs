namespace VRage.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    internal static class CollectionDictExtensions
    {
        public static IEnumerable<TVal> GetOrEmpty<TKey, TValCol, TVal>(this Dictionary<TKey, TValCol> self, TKey key) where TValCol: IEnumerable<TVal>
        {
            TValCol local;
            if (!self.TryGetValue(key, out local))
            {
                return Enumerable.Empty<TVal>();
            }
            return local;
        }

        public static IEnumerable<TVal> GetOrEmpty<TKey, TKey2, TVal>(this Dictionary<TKey, Dictionary<TKey2, TVal>> self, TKey key)
        {
            Dictionary<TKey2, TVal> dictionary;
            if (!self.TryGetValue(key, out dictionary))
            {
                return Enumerable.Empty<TVal>();
            }
            return (IEnumerable<TVal>) dictionary.Values;
        }
    }
}

