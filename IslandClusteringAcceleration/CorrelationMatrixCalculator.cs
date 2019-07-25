using IslandClusteringAcceleration.Contracts;
using IslandClusteringAcceleration.Models;
using System;
using System.Linq;

namespace IslandClusteringAcceleration
{
    public class CorrelationMatrixCalculator
    {
        private ICycleProvider _cycleProvider;
        private ITermCountInTextsProvider _termCountInTextsProvider;
        private ITermOccurrenceCountProvider _termOccurrenceCountProvider;
        private IBinomialProvider _binomialProvider;

        public CorrelationMatrixCalculator(
            ICycleProvider cycleProvider,
            ITermCountInTextsProvider termCountInTextsProvider,
            ITermOccurrenceCountProvider termOccurrenceCountProvider,
            IBinomialProvider binomialProvider)
        {
            _cycleProvider = cycleProvider;
            _termCountInTextsProvider = termCountInTextsProvider;
            _termOccurrenceCountProvider = termOccurrenceCountProvider;
            _binomialProvider = binomialProvider;
        }

        public CorrelationMatrix GetMatrix(Corpus corpus)
        {
            var matrix = new CorrelationMatrix(corpus.UniqueLemmas.Count);

            _cycleProvider.Run(corpus.UniqueLemmas.Count, (i, j) =>
            {
                var cij = GetCorrelation(corpus, i, j);
                var cji = GetCorrelation(corpus, j, i);

                var max = Math.Max(cij, cji);
                var min = Math.Min(cij, cji);

                matrix[i, j] = max == 1 ? min : max;
            });

            return matrix;
        }

        private double GetCorrelation(Corpus corpus, int i, int j)
        {
            int ni = _termCountInTextsProvider.GetCount(corpus, i);
            int nj = _termOccurrenceCountProvider.GetCount(corpus, j);
            int nij = corpus.Texts
                .Where(x => x.Lemmas.Contains(corpus.UniqueLemmas.ElementAt(i)))
                .SelectMany(x => x.Lemmas)
                .Count(x => x == corpus.UniqueLemmas.ElementAt(j));

            if (nij <= ni * nj / corpus.AllLemmas.Count)
            {
                return 1;
            }
            else
            {
                return Math.Pow((double)ni / corpus.AllLemmas.Count, nij) *
                    Math.Pow(1 - (double)ni / corpus.AllLemmas.Count, nj - nij) *
                    _binomialProvider.GetCoefficient(nj, nij);
            }
        }
    }
}
