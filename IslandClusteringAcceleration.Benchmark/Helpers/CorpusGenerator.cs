using IslandClusteringAcceleration.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IslandClusteringAcceleration.Benchmark.Helpers
{
    internal class CorpusGenerator
    {
        private readonly int _termCount;
        private readonly int _textCount;
        private readonly int _termOccurrenceRange;

        public CorpusGenerator(int termCount)
        {
            _termCount = termCount;
            _textCount = (int)Math.Pow(termCount, 0.25);
            _termOccurrenceRange = (_textCount / 5) + 1;
        }

        public Corpus GetCorpus()
        {
            var texts = Enumerable.Range(0, _textCount)
                .Select(x => new List<string>())
                .ToArray();

            for (int i = 0; i < _termCount; i++)
            {
                var term = IndexToTerm(i);
                var textIndexes = GetTermTexts(i);
                var termCounts = GetTermCount(i);

                for (int j = 0; j < textIndexes.Length; j++)
                {
                    texts[textIndexes[j]].AddRange(Enumerable.Repeat(term, termCounts[j]));
                }
            }

            return new Corpus(texts.Select(x => new Text(x)));
        }

        private string IndexToTerm(int index)
        {
            return Convert.ToString(index, 16);
        }

        private int[] GetTermTexts(int index)
        {
            var indexes = Enumerable.Range(
                (index % _textCount) - _termOccurrenceRange, _termOccurrenceRange * 2 + 1)
                .ToArray();

            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] < 0)
                {
                    indexes[i] = _textCount + indexes[i];
                }
                else if (indexes[i] >= _textCount)
                {
                    indexes[i] = indexes[i] % _textCount;
                }
            }

            return indexes;
        }

        private int[] GetTermCount(int index)
        {
            var count = new int[_termOccurrenceRange * 2 + 1];
            var totalCount = _textCount * ((index % _textCount) + 1);

            count[_termOccurrenceRange] = totalCount / 2;
            for (int i = 0; i < count.Length; i++)
            {
                if (i == _termOccurrenceRange)
                {
                    continue;
                }

                count[i] = totalCount / (4 * _termOccurrenceRange);
            }

            return count;
        }
    }
}
