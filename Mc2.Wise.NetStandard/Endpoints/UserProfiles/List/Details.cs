using System.Runtime.Serialization;

namespace Mc2.Wise.NetStandard.Endpoints.UserProfiles.List
{
    public class Details<T>  where T : IDetails
    {
        public T Detail { get; set; }
    }

}