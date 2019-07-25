using IslandClusteringAcceleration.Contracts;
using IslandClusteringAcceleration.Models;
using System.Linq;

namespace IslandClusteringAcceleration.TermCountInTextsProviders
{
    public class Calculus : ITermCountInTextsProvider
    {
        public int GetCount(Corpus corpus, int i)
        {
            return corpus.Texts.
                Where(x => x.Lemmas.Contains(corpus.UniqueLemmas.ElementAt(i))).
                SelectMany(x => x.Lemmas).
                Count();
        }
    }
}
