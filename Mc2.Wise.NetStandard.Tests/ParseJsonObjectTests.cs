using System;
using System.IO;
using Xunit;
using Mc2.Wise.NetStandard.Endpoints.RecipientAccounts.BankAndBranches;
using Mc2.Wise.NetStandard.Endpoints.UserProfiles.List;
using Newtonsoft.Json;

namespace Mc2.Wise.NetStandard.Tests
{
    public class ParseJsonObjectTests
    {
        private readonly char Ds = Path.DirectorySeparatorChar;
        
        [Fact]
        public void ParseBankJsonTest()
        {
            string banks = File.ReadAllText($"DataSamples{Ds}BanksMy.json");

            var responseObject = JsonConvert.DeserializeObject<BankListResponse>(banks);

            Assert.NotNull(responseObject.Banks[0].Code);
        }

        [Fact]
        public void ParseProfileJsonTest()
        {
            string profileJson = File.ReadAllText($"DataSamples{Ds}Profiles.json");

            var userProfilesResponse = JsonConvert.DeserializeObject<Profile[]>(profileJson);

            foreach(var profile in userProfilesResponse)
            {
                switch (profile.Details)
                {
                    case DetailsPersonal detailsPersonal:
                        Assert.NotNull(detailsPersonal.FirstName);
                        Assert.NotNull(detailsPersonal.LastName);
                        break;

                    case DetailsBusiness detailsBusiness:
                        Assert.NotNull(detailsBusiness.Name);
                        break;
                    default:
                        throw new NotImplementedException("Type of Details is not handled:" + profile.Details.GetType());
                }
            }
        }
    }
}
