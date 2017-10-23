using System.Runtime.Serialization;

namespace SearchFight.Searchers.Contracts.Google
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public long totalResults { get; set; }
    }
}
