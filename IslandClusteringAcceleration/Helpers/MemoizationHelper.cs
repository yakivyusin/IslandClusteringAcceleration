using System;
using System.Collections.Generic;

namespace IslandClusteringAcceleration.Helpers
{
    internal class MemoizationHelper<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _memoizedValues = new Dictionary<TKey, TValue>();

        public TValue GetValue(TKey key, Func<TKey, TValue> calculationCallback)
        {
            if (!_memoizedValues.TryGetValue(key, out TValue value))
            {
                value = calculationCallback(key);
                _memoizedValues.Add(key, value);
            }

            return value;
        }
    }
}
