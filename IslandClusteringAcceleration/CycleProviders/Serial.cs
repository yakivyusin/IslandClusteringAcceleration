using IslandClusteringAcceleration.Contracts;
using System;

namespace IslandClusteringAcceleration.CycleProviders
{
    public class Serial : ICycleProvider
    {
        public void Run(int matrixDimension, Action<int, int> loopAction)
        {
            for (int i = 0; i < matrixDimension; i++)
            {
                for (int j = i + 1; j < matrixDimension; j++)
                {
                    loopAction(i, j);
                }
            }
        }
    }
}
