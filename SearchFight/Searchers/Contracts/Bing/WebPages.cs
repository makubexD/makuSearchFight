using System.Runtime.Serialization;

namespace SearchFight.Searchers.Contracts.Bing
{
    [DataContract]
    public class WebPages
    {
        [DataMember]
        public long totalEstimatedMatches { get; set; }
    }
}
