using Azihub.GlobalData.Base.Country;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.Wise.NetStandard.Endpoints.RecipientAccounts.BankAndBranches
{
    public class BankListRequest
    {
        public BankListRequest(CountryIso2Code countryCode)
        {
            Country = countryCode;
        }

        [JsonProperty("country")]
        public CountryIso2Code Country { get; }
    }
}
