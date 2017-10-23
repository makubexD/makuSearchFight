using System.Collections.Generic;

namespace SearchFight.Model
{
    public class TotalSearchResult
    {
        public List<SearchResult> SearchResults { get; set; }
        public List<SearchWinner> IndividualWinners { get; set; }
        public string GlobalWinner { get; set; }
    }
}
