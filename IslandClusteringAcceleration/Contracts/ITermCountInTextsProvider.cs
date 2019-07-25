using IslandClusteringAcceleration.Models;

namespace IslandClusteringAcceleration.Contracts
{
    public interface ITermCountInTextsProvider
    {
        int GetCount(Corpus corpus, int i);
    }
}
