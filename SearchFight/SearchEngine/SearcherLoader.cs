using System;
using System.Collections.Generic;
using SearchFight.Configuration.Interfaces;
using SearchFight.SearchEngine.Interfaces;

namespace SearchFight.SearchEngine
{
    public class SearcherLoader : ISearcherLoader
    {
        private ISearchFightSectionSetup SearchFightSectionSetup { get; }

        public SearcherLoader(ISearchFightSectionSetup searchFightSectionSetup)
        {
            SearchFightSectionSetup = searchFightSectionSetup;
        }

        public IEnumerable<ISearcher> Handle()
        {
            var seacherList = new List<ISearcher>();

            foreach (var searcherElement in SearchFightSectionSetup.Searchers)
            {
                var searcherType = Type.GetType(searcherElement.Type);
                if (searcherType == null)
                    throw new InvalidOperationException($"[{searcherElement.Type}] type could not be loaded.");

                var searcher = (ISearcher)Activator.CreateInstance(searcherType,
                    searcherElement.Name, searcherElement.Url, searcherElement.RequestHeaders);

                seacherList.Add(searcher);
            }

            return seacherList;
        }
    }
}
