using System;
using System.Collections.Concurrent;

namespace IslandClusteringAcceleration.Helpers
{
    internal class MemoizationHelper<TKey, TValue>
    {
        private ConcurrentDictionary<TKey, TValue> _memoizedValues = new ConcurrentDictionary<TKey, TValue>();

        public TValue GetValue(TKey key, Func<TKey, TValue> calculationCallback)
        {
            return _memoizedValues.GetOrAdd(key, calculationCallback);
        }
    }
}
