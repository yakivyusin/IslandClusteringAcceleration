using System;
using System.Collections.Generic;
using System.Linq;

namespace IslandClusteringAcceleration.Models
{
    public class Corpus
    {
        private Text[] _texts;
        private Lazy<IReadOnlyCollection<string>> _allLemmas;
        private Lazy<IReadOnlyCollection<string>> _uniqueLemmas;

        public Corpus(IEnumerable<Text> texts)
        {
            _texts = texts.ToArray();
            _allLemmas = new Lazy<IReadOnlyCollection<string>>(() => _texts.SelectMany(x => x.Lemmas).ToList());
            _uniqueLemmas = new Lazy<IReadOnlyCollection<string>>(() => _texts.SelectMany(x => x.Lemmas).Distinct().ToList());
        }

        public IReadOnlyCollection<Text> Texts => _texts;

        public IReadOnlyCollection<string> AllLemmas => _allLemmas.Value;

        public IReadOnlyCollection<string> UniqueLemmas => _uniqueLemmas.Value;

        public override string ToString()
        {
            return $"Ndocs: {Texts.Count}; Nterms: {UniqueLemmas.Count}";
        }
    }
}
