using System.Runtime.Serialization;

namespace SearchFight.Searchers.Contracts.Google
{
    [DataContract]
    public class GoogleSearchRoot
    {
        [DataMember]
        public Queries queries { get; set; }
    }
}
