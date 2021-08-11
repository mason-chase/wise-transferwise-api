using Mc2.Wise.NetStandard.Endpoints.UserProfiles.List.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.Wise.NetStandard.Endpoints.UserProfiles.List
{
    /*
     * 
     * {
      "id": <your personal profile id>,
      "type": "personal",
      "details": {
        "firstName": "Oliver",
        "lastName": "Wilson",
        "dateOfBirth": "1977-07-01",
        "phoneNumber": "+3725064992",
        "avatar": "",
        "occupation": "",
        "occupations": null,
        "primaryAddress": null,
        "firstNameInKana": null,
        "lastNameInKana": null
      }
    }
    */
    //[JsonConverter(typeof(ProfileConverter))]
    public class Profile // <T> where T : IDetails
    {
        public Profile()
        {

        }
        public Profile(ulong id, ProfileType type, object details)

        {
            Id = id;
            Type = type;
            DetailsDynamic = details;
            //if(Type == ProfileType.Personal)
            //    Details  = JsonConvert.DeserializeObject<DetailsPersonal>(details);
            //else
            //    Details = JsonConvert.DeserializeObject<DetailsBusiness>(details);
        }

        //public Profile<IDetails> GetProfile()
        //{
        //    if (Type == ProfileType.Business)
        //        return new Profile<DetailsBusiness>((IDetails) Details);

        //    return new Profile<DetailsPersonal>(Details);
        //}

        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("type")]
        public ProfileType Type { get; set; }

        [JsonProperty("details")]
        public object DetailsDynamic
        {
            get
            {
                return Details;
            }
            set
            {
                if (Type == ProfileType.Business)
                    Details = ((JToken) value).ToObject<DetailsBusiness>();
                else if (Type == ProfileType.Personal)
                    Details = ((JToken)value).ToObject<DetailsPersonal>();
            }
        }
        public IDetails Details { get; private set; }
    }

    public class Profile<T> : Profile
        where T : IDetails
    {
        public Profile(IDetails details)
        {
            Details = (T)details;
        }

        public new T Details { get; set; }
    }
}
