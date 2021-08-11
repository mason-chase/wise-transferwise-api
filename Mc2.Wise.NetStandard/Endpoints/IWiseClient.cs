using BankListRequest = Mc2.Wise.NetStandard.Endpoints.RecipientAccounts.BankAndBranches.BankListRequest;
using BankListResponse = Mc2.Wise.NetStandard.Endpoints.RecipientAccounts.BankAndBranches.BankListResponse;

using ProfileListRequest = Mc2.Wise.NetStandard.Endpoints.UserProfiles.List.UserProfilesRequest;
using ProfileListResponse = Mc2.Wise.NetStandard.Endpoints.UserProfiles.List.UserProfilesResponse;

namespace Mc2.Wise.NetStandard
{
    public interface IWiseClient
    {
        BankListResponse GetBankList(BankListRequest bankListRequest);
        ProfileListResponse GetUserProfiles(ProfileListRequest profileListRequest);
    }
}