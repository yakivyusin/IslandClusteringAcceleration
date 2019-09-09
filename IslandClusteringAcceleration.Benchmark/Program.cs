using BenchmarkDotNet.Running;
using IslandClusteringAcceleration.Benchmark.Benchmarks;
using System.Linq;

namespace IslandClusteringAcceleration.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                AllBenchmark.CorpusSizes = args
                    .Select(x => int.TryParse(x, out int result) ? result : 0)
                    .Where(x => x != 0)
                    .ToArray();
            }

            BenchmarkRunner.Run<AllBenchmark>();
        }
    }
}
