using IslandClusteringAcceleration.Models;

namespace IslandClusteringAcceleration.Contracts
{
    public interface ITermOccurrenceCountProvider
    {
        int GetCount(Corpus corpus, int j);
    }
}
