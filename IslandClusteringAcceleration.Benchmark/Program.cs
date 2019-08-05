using BenchmarkDotNet.Running;
using IslandClusteringAcceleration.Benchmark.Benchmarks;

namespace IslandClusteringAcceleration.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<AllBenchmark>();
        }
    }
}
