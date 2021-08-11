using Mc2.Wise.NetStandard.Endpoints.UserProfiles.List.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.Wise.NetStandard.Endpoints.UserProfiles.List
{
    //[JsonConverter(typeof(ProfilesResponseConverter))]
    public class UserProfilesResponse
    {   
        public UserProfilesResponse(Profile[] profiles)
        {
            Profiles = profiles;
        }
        public Profile[] Profiles { get; }
    }
}
