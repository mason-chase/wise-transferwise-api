using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.Wise.NetStandard.Endpoints.RecipientAccounts.BankAndBranches
{
    public class Bank
    {
        public Bank(string code, string title)
        {
            Code = code;
            Title = title;
        }

        [JsonProperty("code")]
        public string Code { get; }

        [JsonProperty("title")]
        public string Title { get; }
    }
}
