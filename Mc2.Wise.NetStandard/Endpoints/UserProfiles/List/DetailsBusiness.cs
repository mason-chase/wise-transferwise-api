using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.Wise.NetStandard.Endpoints.UserProfiles.List
{
    /*
     *  "name": "ABC Logistics Ltd",
        "registrationNumber": "12144939",
        "acn": null,
        "abn": null,
        "arbn": null,
        "companyType": "LIMITED",
        "companyRole": "OWNER",
        "descriptionOfBusiness": "CHARITY_AND_NOT_FOR_PROFIT",
        "webpage": "https://abc-logistics.com",
        "primaryAddress": null,
        "businessCategory": "CHARITY_AND_NOT_FOR_PROFIT",
        "businessSubCategory": "CHARITY_ALL_ACTIVITIES"
    */
    public class DetailsBusiness : IDetails
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("registrationNumber")]
        public string RegistrationNumber { get; set; }

        [JsonProperty("acn")]
        public string Acn { get; set; }
        
        [JsonProperty("abn")]
        public string Abn { get; set; }
        
        [JsonProperty("arbn")]
        public string Arbn { get; set; }
        
        [JsonProperty("companyType")]
        public string CompanyType { get; set; }
        
        [JsonProperty("companyRole")]
        public string CompanyRole { get; set; }
        
        [JsonProperty("descriptionOfBusiness")]
        public string DescriptionOfBusiness { get; set; }
        
        [JsonProperty("webpage")]
        public string Webpage { get; set; }
        
        [JsonProperty("primaryAddress")]
        public string PrimaryAddress { get; set; }
        
        [JsonProperty("businessCategory")]
        public string BusinessCategory { get; set; }
        
        [JsonProperty("businessSubCategory")]
        public string BusinessSubCategory { get; set; }

    }
}
