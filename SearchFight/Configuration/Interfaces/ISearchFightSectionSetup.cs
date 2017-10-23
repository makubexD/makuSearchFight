using System.Collections.Generic;

namespace SearchFight.Configuration.Interfaces
{
    public interface ISearchFightSectionSetup
    {
        IEnumerable<SearcherElementSetup> Searchers { get; }
    }
}
