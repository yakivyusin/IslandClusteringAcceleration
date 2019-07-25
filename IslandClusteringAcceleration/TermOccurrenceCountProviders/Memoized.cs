using IslandClusteringAcceleration.Helpers;
using IslandClusteringAcceleration.Models;

namespace IslandClusteringAcceleration.TermOccurrenceCountProviders
{
    public class Memoized : Calculus
    {
        private MemoizationHelper<int, int> _memoizationHelper = new MemoizationHelper<int, int>();

        public override int GetCount(Corpus corpus, int j)
        {
            return _memoizationHelper.GetValue(j, (index) => base.GetCount(corpus, index));
        }
    }
}
