using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mc2.Wise.NetStandard.Endpoints.UserProfiles.List.Json
{
    public class ProfilesResponseConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Profile[] result;

            if (reader.TokenType == JsonToken.StartArray)
            {
                var legacyArray = (JArray) JArray.ReadFrom(reader);
                var list = legacyArray[1].ToObject<Profile>();
                //list.ForEach(x => x.ToObject<Profile>());
                result =  legacyArray.ToObject<Profile[]>();
                UserProfilesResponse userProfileResponse = new UserProfilesResponse(result);

                return userProfileResponse;
            }
            throw new Exception("Failed to get array of object");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}
