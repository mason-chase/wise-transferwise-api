using Azihub.GlobalData.Base.Country;
using Mc2.Wise.NetStandard.Endpoints.RecipientAccounts.BankAndBranches;
using Mc2.Wise.NetStandard.Tests.Settings;
using System;
using Xunit;
using BankListRequest = Mc2.Wise.NetStandard.Endpoints.RecipientAccounts.BankAndBranches.BankListRequest;
using BankListResponse = Mc2.Wise.NetStandard.Endpoints.RecipientAccounts.BankAndBranches.BankListResponse;

using ProfileListRequest = Mc2.Wise.NetStandard.Endpoints.UserProfiles.List.UserProfilesRequest;
using ProfileListResponse = Mc2.Wise.NetStandard.Endpoints.UserProfiles.List.UserProfilesResponse;


namespace Mc2.Wise.NetStandard.Tests
{
    public class WiseClientTests
    {
        [Fact]
        public void GetUsBanksTest()
        {

            WiseClient wiseClient = new(TestSettings.Settings.WiseApiKey, TestSettings.Settings.WiseApiSandbox);
            BankListRequest request = new(CountryIso2Code.UnitedStates);

            BankListResponse response = wiseClient.GetBankList(request);
            Assert.True(response.Banks.Length > 0);
            Assert.NotNull(response.Banks[0].Code);
        }

        [Fact]
        public void GetMyBanksTest()
        {

            WiseClient wiseClient = new(TestSettings.Settings.WiseApiKey, TestSettings.Settings.WiseApiSandbox);
            BankListRequest request = new(CountryIso2Code.Malaysia);

            var response = wiseClient.GetBankList(request);
            Assert.True(response.Banks.Length > 0);
            Assert.NotNull(response.Banks[0].Code);
        }

        [Fact]
        public void GetProfilesTest()
        {
            WiseClient wiseClient = new(TestSettings.Settings.WiseApiKey, TestSettings.Settings.WiseApiSandbox);
            ProfileListRequest request = new();

            ProfileListResponse response = wiseClient.GetUserProfiles(request);

            Assert.NotNull(response.Profiles[0].Type);
            Assert.NotNull(response.Profiles[0].Details);
        }

        // 
    }
}
