using Azihub.Utilities.Base.Extensions.Object;
using Mc2.Wise.NetStandard.ClientExceptions;
using Mc2.Wise.NetStandard.ClientProperties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Mc2.Wise.NetStandard.Endpoints.UserProfiles.List;
using Mc2.Wise.NetStandard.Endpoints.RecipientAccounts.BankAndBranches;

namespace Mc2.Wise.NetStandard
{
    public class WiseClient : IWiseClient
    {
        public string ApiKey { get; }

        private readonly bool _sandbox;

        private readonly HttpClient HttpClient;
        public WiseClient(string apiKey, bool sandbox)
        {
            ApiKey = apiKey;
            _sandbox = sandbox;
            HttpClient = new HttpClient
            {
                BaseAddress = _sandbox ? new Uri("https://api.sandbox.transferwise.tech") : new Uri("https://api.transferwise.com")
            };

            HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }

        public BankListResponse GetBankList(BankListRequest bankListRequest)
        {
            Response<BankListResponse> response = SendApiRequest<BankListResponse>(bankListRequest, "/v1/banks");
            return response.Data;
        }

        public UserProfilesResponse GetUserProfiles(UserProfilesRequest userProfilesRequest)
        {
            Response<Profile[]> profiles= SendApiRequest<Profile[]>(userProfilesRequest, "/v1/profiles");
            UserProfilesResponse userProfilesResponse  = new UserProfilesResponse(profiles.Data);
            return userProfilesResponse;
        }

        private Response<T> SendApiRequest<T>(object requestParams, string endpoint)
        {
            string queryParams = requestParams.GetQueryString(SelectCase.PascalToSnakeCase);
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{endpoint}?{queryParams}");
            HttpResponseMessage responseMessage = HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            string body = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            try
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseBody = JsonConvert.DeserializeObject<T>(body);
                    return new Response<T>() { Data = responseBody };

                }
                }
                catch (JsonSerializationException ex)
            {
#if DEBUG
                Debugger.Log(1, "Error", ex.Message);
                Debugger.Break();

#else
                throw new BadServerResponseException(responseMessage, body);
#endif
            }




            Response<T> response = JsonConvert.DeserializeObject<Response<T>>(body);

            if (response is null)
            {
                throw new BadServerResponseException(responseMessage);
            }
            else if (response is null)
            {
                throw new BadServerResponseException(responseMessage, body);
            }
            else
                throw new BadRequestException(body);
        }
    }
}
