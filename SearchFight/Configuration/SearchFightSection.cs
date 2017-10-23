using System.Configuration;

namespace SearchFight.Configuration
{
    public class SearchFightSection : ConfigurationSection
    {
        public static SearchFightSection Configuration { get; } = ConfigurationManager.GetSection("searchFight") as SearchFightSection;

        [ConfigurationProperty(Attributes.Searchers)]
        public SearcherCollection SearcherCollection => this[Attributes.Searchers] as SearcherCollection;


        private struct Attributes
        {
            public const string Searchers = "searchers";
        }
    }
}
