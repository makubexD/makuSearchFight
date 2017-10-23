using System.Collections.Generic;
using SearchFight.Model;

namespace SearchFight.SearchEngine.Interfaces
{
    public interface IWinnerSearchCalculator
    {
        TotalSearchResult Handle(IEnumerable<SearchResult> searchResults);
    }
}
