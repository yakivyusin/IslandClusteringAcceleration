using IslandClusteringAcceleration.Contracts;
using IslandClusteringAcceleration.Models;
using System.Linq;

namespace IslandClusteringAcceleration.TermOccurrenceCountProviders
{
    public class Calculus : ITermOccurrenceCountProvider
    {
        public virtual int GetCount(Corpus corpus, int j)
        {
            return corpus.
                AllLemmas.
                Count(x => x == corpus.UniqueLemmas.ElementAt(j));
        }
    }
}
