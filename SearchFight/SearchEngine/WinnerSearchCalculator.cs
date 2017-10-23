using System.Collections.Generic;
using System.Linq;
using SearchFight.Model;
using SearchFight.SearchEngine.Interfaces;

namespace SearchFight.SearchEngine
{
    public class WinnerSearchCalculator : IWinnerSearchCalculator
    {
        public TotalSearchResult Handle(IEnumerable<SearchResult> searchResults)
        {
            string[] searchers = { };
            if (searchResults.Any())
                searchers = searchResults.First().SearcherResults.Select(sr => sr.SearcherName).ToArray();

            var individualWinners = new List<SearchWinner>();
            foreach (var searcher in searchers)
            {
                individualWinners.Add(new SearchWinner
                {
                    SearcherName = searcher,
                    SearchTerm = GetWinnerBySearcher(searcher, searchResults)
                });
            }

            return new TotalSearchResult
            {
                SearchResults = searchResults.ToList(),
                IndividualWinners = individualWinners,
                GlobalWinner = GetGlobalWinner(searchResults)
            };
        }

        private string GetGlobalWinner(IEnumerable<SearchResult> searchResults)
        {
            var winnerTotalSearch = default(long);
            var winnerSearchTerm = string.Empty;

            foreach (var searchResult in searchResults)
            {
                var currentTotalSearch = searchResult.SearcherResults.Sum(sr => sr.Total);

                if (currentTotalSearch < winnerTotalSearch) continue;
                winnerTotalSearch = currentTotalSearch;
                winnerSearchTerm = searchResult.SearchTerm;
            }

            return winnerSearchTerm;
        }

        private string GetWinnerBySearcher(string searcherName, IEnumerable<SearchResult> searchResults)
        {
            var maxTotalSearch = default(long);
            var winnerSearcher = string.Empty;

            foreach (var searchResult in searchResults)
            {
                var searchResponse = searchResult.SearcherResults
                    .First(sr => sr.SearcherName.Equals(searcherName));

                if (searchResponse.Total < maxTotalSearch) continue;
                maxTotalSearch = searchResponse.Total;
                winnerSearcher = searchResponse.SearchTerm;
            }

            return winnerSearcher;
        }
    }
}
