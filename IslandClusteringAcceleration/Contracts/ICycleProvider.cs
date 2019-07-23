using System;

namespace IslandClusteringAcceleration.Contracts
{
    public interface ICycleProvider
    {
        void Run(int matrixDimension, Action<int, int> loopAction);
    }
}
