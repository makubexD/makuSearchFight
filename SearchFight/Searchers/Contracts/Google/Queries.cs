using System.Runtime.Serialization;

namespace SearchFight.Searchers.Contracts.Google
{
    [DataContract]
    public class Queries
    {
        [DataMember]
        public Request[] request { get; set; }
    }
}
