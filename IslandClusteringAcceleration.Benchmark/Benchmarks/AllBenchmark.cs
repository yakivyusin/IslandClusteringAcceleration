using BenchmarkDotNet.Attributes;
using IslandClusteringAcceleration.Benchmark.Helpers;
using IslandClusteringAcceleration.CycleProviders;
using IslandClusteringAcceleration.Models;
using System.Collections.Generic;
using System.Linq;
using Ni = IslandClusteringAcceleration.TermCountInTextsProviders;
using Nj = IslandClusteringAcceleration.TermOccurrenceCountProviders;

namespace IslandClusteringAcceleration.Benchmark.Benchmarks
{
    [RPlotExporter]
    [CsvMeasurementsExporter]
    [JsonExporterAttribute.Brief]
    [MemoryDiagnoser]
    public class AllBenchmark
    {
        private static readonly int[] _corpusSizes = new[] { 82 };

        // Serial calculators
        private CorrelationMatrixCalculator _serial00 = new CorrelationMatrixCalculator(new Serial(),
            new Ni.Calculus(), new Nj.Calculus(), new BinomialProviders.Calculus());
        private CorrelationMatrixCalculator _serial10 = new CorrelationMatrixCalculator(new Serial(),
            new Ni.Memoized(), new Nj.Calculus(), new BinomialProviders.Calculus());
        private CorrelationMatrixCalculator _serial01 = new CorrelationMatrixCalculator(new Serial(),
            new Ni.Calculus(), new Nj.Memoized(), new BinomialProviders.Calculus());
        private CorrelationMatrixCalculator _serial11 = new CorrelationMatrixCalculator(new Serial(),
            new Ni.Memoized(), new Nj.Memoized(), new BinomialProviders.Calculus());

        // Parallel calculators
        private CorrelationMatrixCalculator _parallel00 = new CorrelationMatrixCalculator(new Parallel(),
            new Ni.Calculus(), new Nj.Calculus(), new BinomialProviders.Calculus());
        private CorrelationMatrixCalculator _parallel10 = new CorrelationMatrixCalculator(new Parallel(),
            new Ni.Memoized(), new Nj.Calculus(), new BinomialProviders.Calculus());
        private CorrelationMatrixCalculator _parallel01 = new CorrelationMatrixCalculator(new Parallel(),
            new Ni.Calculus(), new Nj.Memoized(), new BinomialProviders.Calculus());
        private CorrelationMatrixCalculator _parallel11 = new CorrelationMatrixCalculator(new Parallel(),
            new Ni.Memoized(), new Nj.Memoized(), new BinomialProviders.Calculus());

        // Parallel2 calculators
        private CorrelationMatrixCalculator _parallelTwo00 = new CorrelationMatrixCalculator(new Parallel2(),
            new Ni.Calculus(), new Nj.Calculus(), new BinomialProviders.Calculus());
        private CorrelationMatrixCalculator _parallelTwo10 = new CorrelationMatrixCalculator(new Parallel2(),
            new Ni.Memoized(), new Nj.Calculus(), new BinomialProviders.Calculus());
        private CorrelationMatrixCalculator _parallelTwo01 = new CorrelationMatrixCalculator(new Parallel2(),
            new Ni.Calculus(), new Nj.Memoized(), new BinomialProviders.Calculus());
        private CorrelationMatrixCalculator _parallelTwo11 = new CorrelationMatrixCalculator(new Parallel2(),
            new Ni.Memoized(), new Nj.Memoized(), new BinomialProviders.Calculus());

        [ParamsSource(nameof(TestCorpuses))]
        public Corpus Corpus { get; set; }

        [Benchmark(Description = "Serial / None / None", Baseline = true)]
        public void Serial00() => _serial00.GetMatrix(Corpus);

        [Benchmark(Description = "Serial / Memo / None")]
        public void Serial10() => _serial10.GetMatrix(Corpus);

        [Benchmark(Description = "Serial / None / Memo")]
        public void Serial01() => _serial01.GetMatrix(Corpus);

        [Benchmark(Description = "Serial / Memo / Memo")]
        public void Serial11() => _serial11.GetMatrix(Corpus);

        [Benchmark(Description = "Parallel / None / None")]
        public void Parallel00() => _parallel00.GetMatrix(Corpus);

        [Benchmark(Description = "Parallel / Memo / None")]
        public void Parallel10() => _parallel10.GetMatrix(Corpus);

        [Benchmark(Description = "Parallel / None / Memo")]
        public void Parallel01() => _parallel01.GetMatrix(Corpus);

        [Benchmark(Description = "Parallel / Memo / Memo")]
        public void Parallel11() => _parallel11.GetMatrix(Corpus);

        [Benchmark(Description = "Parallel2 / None / None")]
        public void ParallelTwo00() => _parallelTwo00.GetMatrix(Corpus);

        [Benchmark(Description = "Parallel2 / Memo / None")]
        public void ParallelTwo10() => _parallelTwo10.GetMatrix(Corpus);

        [Benchmark(Description = "Parallel2 / None / Memo")]
        public void ParallelTwo01() => _parallelTwo01.GetMatrix(Corpus);

        [Benchmark(Description = "Parallel2 / Memo / Memo")]
        public void ParallelTwo11() => _parallelTwo11.GetMatrix(Corpus);

        public IEnumerable<Corpus> TestCorpuses => _corpusSizes.Select(x => new CorpusGenerator(x).GetCorpus());
    }
}
