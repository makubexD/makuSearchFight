using System.Collections.Generic;

namespace SearchFight.Model
{
    public class SearchResult
    {
        public string SearchTerm { get; set; }
        public IEnumerable<SearcherResponse> SearcherResults { get; set; }
    }
}
