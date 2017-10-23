using System.Collections.Generic;

namespace SearchFight.Configuration
{
    public class SearcherElementSetup
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }

        public IReadOnlyDictionary<string, string> RequestHeaders { get; set; }
    }
}
