using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Mc2.Wise.NetStandard.Endpoints.UserProfiles.List.Json
{


    public class ProfileConverter : JsonConverter
    {
        static string GetJsonProperty<T>(Expression<Func<T>> expr)
        {
            var mexpr = expr.Body as MemberExpression;
            if (mexpr == null) return null;
            if (mexpr.Member == null) return null;
            object[] attrs = mexpr.Member.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
            if (attrs == null || attrs.Length == 0) return null;
            JsonPropertyAttribute desc = attrs[0] as JsonPropertyAttribute;
            if (desc == null) return null;
            return desc.PropertyName;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            PropertyInfo[] properties = typeof(Profile).GetProperties();
            properties.ToArray().Where(x => x.Name == nameof(Profile.Type));
            Profile profile = new Profile();

            foreach (var property in properties) 
            {
                string profileType = GetJsonProperty(() => profile.Type);
                
            }

            if (reader.TokenType == JsonToken.StartObject)
            {
                var legacyArray = (JObject) JObject.ReadFrom(reader);
                legacyArray.ToObject<Profile>();
                //var legacyArray.GetValue(profileType) == )
                //profile.Details = legacyArray.GetValue(jsonProperty);
                //list.ForEach(x => x.ToObject<Profile>());
                
                return profile;
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
