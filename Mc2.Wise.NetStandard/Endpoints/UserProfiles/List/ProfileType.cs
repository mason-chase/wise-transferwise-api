using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Mc2.Wise.NetStandard.Endpoints.UserProfiles.List
{
    public enum ProfileType
    {
        [EnumMember(Value = "personal")]
        Personal,
        [EnumMember(Value = "business")]
        Business
    }
}
