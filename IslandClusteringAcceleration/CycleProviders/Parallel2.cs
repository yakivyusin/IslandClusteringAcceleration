using IslandClusteringAcceleration.Contracts;
using System;
using Tpl = System.Threading.Tasks.Parallel;

namespace IslandClusteringAcceleration.CycleProviders
{
    public class Parallel2 : ICycleProvider
    {
        public void Run(int matrixDimension, Action<int, int> loopAction)
        {
            Tpl.For(0, matrixDimension, (int i) =>
            {
                Tpl.For(i + 1, matrixDimension, (int j) =>
                {
                    loopAction(i, j);
                });
            });
        }
    }
}
