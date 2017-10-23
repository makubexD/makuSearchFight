using System.Collections.Generic;
using System.Threading.Tasks;
using SearchFight.Model;
using SearchFight.SearchEngine.Interfaces;

namespace SearchFight.Searchers
{
    public abstract class BaseSearcher : ISearcher
    {
        public string Name { get; }
        public string Url { get; }
        public Dictionary<string, string> Headers { get; }

        protected BaseSearcher(string name, string url)
        {
            Name = name;
            Url = url;
        }

        protected BaseSearcher(string name, string url, Dictionary<string, string> headers)
            : this(name, url)
        {
            Headers = headers;
        }
        
        public abstract Task<SearcherResponse> Handle(string searchTerm);
    }
}
