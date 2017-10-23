using System.Collections.Generic;

namespace SearchFight.SearchEngine.Interfaces
{
    public interface ISearcherLoader
    {
        IEnumerable<ISearcher> Handle();
    }
}
