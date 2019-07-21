using System.Collections.Generic;
using System.Linq;

namespace IslandClusteringAcceleration.Models
{
    public class Text
    {
        private string[] _lemmas;
        
        public Text(IEnumerable<string> lemmas)
        {
            _lemmas = lemmas.ToArray();
        }

        public IReadOnlyCollection<string> Lemmas => _lemmas;
    }
}
