using Newtonsoft.Json;
using System;

namespace Mc2.Wise.NetStandard.Endpoints.UserProfiles.List
{
    /*
     * "firstName": "Oliver",
        "lastName": "Wilson",
        "dateOfBirth": "1977-07-01",
        "phoneNumber": "+3725064992",
        "avatar": "",
        "occupation": "",
        "occupations": null,
        "primaryAddress": null,
        "firstNameInKana": null,
        "lastNameInKana": null
    */
    public class DetailsPersonal : IDetails
    {
        [JsonProperty("firstName")]
        public string FirstName { get; }

        [JsonProperty("lastName")]
        public string LastName { get; }

        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; }

        [JsonProperty("phoneNumber")]
        public ulong PhoneNumber { get; }

        [JsonProperty("avatar")]
        public string Avatar { get; }

        [JsonProperty("occupation")]
        public string Occupation { get; }

        [JsonProperty("occupations")]
        public string Occupations { get; }

        [JsonProperty("primaryAddress")]
        public string PrimaryAddress { get; }

        [JsonProperty("firstNameInKana")]
        public string FirstNameInKana { get; }

        [JsonProperty("lastNameInKana")]
        public string LastNameInKana { get; }
    }
}