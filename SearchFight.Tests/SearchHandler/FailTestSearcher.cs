using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SearchFight.Model;
using SearchFight.SearchEngine.Interfaces;

namespace SearchFight.Tests.SearchHandler
{
    public class FailTestSearcher : ISearcher
    {
        public string Name => nameof(FailTestSearcher);


        public FailTestSearcher()
        {
        }
        public FailTestSearcher(string name, string url)
        {
        }
        public FailTestSearcher(string name, string url, Dictionary<string, string> headers)
        {
        }

        public async Task<SearcherResponse> Handle(string searchTerm)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }
    }
}
