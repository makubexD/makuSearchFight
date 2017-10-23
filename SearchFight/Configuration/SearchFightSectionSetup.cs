using System.Collections.Generic;
using SearchFight.Configuration.Interfaces;

namespace SearchFight.Configuration
{
    public class SearchFightSectionSetup : ISearchFightSectionSetup
    {
        public SearchFightSectionSetup(SearchFightSection searchFightSection)
        {
            LoadConfiguration(searchFightSection);
        }

        public IEnumerable<SearcherElementSetup> Searchers { get; private set; }


        private void LoadConfiguration(SearchFightSection searchFightSection)
        {
            var searchers = new List<SearcherElementSetup>();
            foreach (SearcherElement searcherElement in searchFightSection.SearcherCollection)
            {
                var requestHeaders = new Dictionary<string, string>();
                foreach (HeaderElement header in searcherElement.HeaderCollection)
                {
                    requestHeaders.Add(header.Key, header.Value);
                }

                searchers.Add(new SearcherElementSetup
                {
                    Name = searcherElement.Name,
                    Type = searcherElement.Type,
                    Url = searcherElement.Url,
                    RequestHeaders = requestHeaders
                });
            }

            Searchers = searchers;
        }
    }
}
