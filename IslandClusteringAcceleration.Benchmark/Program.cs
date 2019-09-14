using BenchmarkDotNet.Running;
using IslandClusteringAcceleration.Benchmark.Benchmarks;
using System.Linq;

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
