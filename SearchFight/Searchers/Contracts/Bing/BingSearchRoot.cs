using System.Runtime.Serialization;

namespace SearchFight.Searchers.Contracts.Bing
{
    [DataContract]
    public class BingSearchRoot
    {
        [DataMember]
        public WebPages webPages { get; set; }
    }
}
