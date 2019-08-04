using System;
using System.Collections.Generic;

namespace IslandClusteringAcceleration.Helpers
{
    internal class MemoizationHelper<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _memoizedValues = new Dictionary<TKey, TValue>();
        private object _lock = new object();

        public TValue GetValue(TKey key, Func<TKey, TValue> calculationCallback)
        {
            if (!_memoizedValues.TryGetValue(key, out TValue value))
            {
                value = calculationCallback(key);

                lock (_lock)
                {
                    if (!_memoizedValues.ContainsKey(key))
                    {
                        _memoizedValues.Add(key, value);
                    }
                }
            }

            return value;
        }
    }
}
