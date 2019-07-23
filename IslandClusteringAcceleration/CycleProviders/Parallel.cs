using IslandClusteringAcceleration.Contracts;
using System;
using Tpl = System.Threading.Tasks.Parallel;

namespace IslandClusteringAcceleration.CycleProviders
{
    public class Parallel : ICycleProvider
    {
        public void Run(int matrixDimension, Action<int, int> loopAction)
        {
            Tpl.For(0, matrixDimension, (int i) =>
            {
                for (int j = i + 1; j < matrixDimension; j++)
                {
                    loopAction(i, j);
                }
            });
        }
    }
}
