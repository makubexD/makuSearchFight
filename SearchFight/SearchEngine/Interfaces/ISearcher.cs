using System.Threading.Tasks;
using SearchFight.Model;

namespace SearchFight.SearchEngine.Interfaces
{
    public interface ISearcher
    {
        string Name { get; }
        Task<SearcherResponse> Handle(string searchTerm);
    }
}
