using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mc2.Wise.NetStandard.Endpoints.RecipientAccounts.BankAndBranches
{
    /*
     * 
     * Example:
     *  {
     *       "values": [
     *           {
     *               "code": "003",
     *               "title": "STANDARD CHARTERED BANK (HONG KONG) LIMITED"
     *           },
     *           {
     *               "code": "552",
     *               "title": "AAREAL BANK AG, WIESBADEN, GERMANY"
     *           },
     *           {
     *               "code": "307",
     *               "title": "ABN AMRO BANK N.V."
     *           },
     *           {
     *               "code": "222",
     *               "title": "AGRICULTURAL BANK OF CHINA LIMITED"
     *           },
     *           {
     *               "code": "525",
     *               "title": "ZIBO CITY COMMERCIAL BANK, SHANDONG"
     *           }
     *       ]
     *  }
    */
    public class BankListResponse
    {
        [JsonProperty("values")]
        public Bank[] Banks { get; set; }
    }
}
