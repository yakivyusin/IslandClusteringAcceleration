using IslandClusteringAcceleration.Helpers;
using IslandClusteringAcceleration.Models;

namespace IslandClusteringAcceleration.TermCountInTextsProviders
{
    public class Memoized : Calculus
    {
        private MemoizationHelper<int, int> _memoizationHelper = new MemoizationHelper<int, int>();

        public override int GetCount(Corpus corpus, int i)
        {
            return _memoizationHelper.GetValue(i, (index) => base.GetCount(corpus, index));
        }
    }
}
