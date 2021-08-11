using System;
using System.Net.Http;

namespace Mc2.Wise.NetStandard.ClientExceptions
{
    public class BadServerResponseException : Exception
    {
        /// <summary>
        /// In case body is null
        /// </summary>
        /// <param name="response"></param>
        public BadServerResponseException(HttpResponseMessage response) :
            base($"Bad server response code: {response.StatusCode}, Response Headers: {response.Headers}")
        {
            Response = response;
        }

        /// <summary>
        /// Body is not null but it doesn't have "Status" property.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="body"></param>
        public BadServerResponseException(HttpResponseMessage response, string body) : 
            base($"Bad server response. [body: {body}")
        {
            Response = response;
        }

        public HttpResponseMessage Response { get; }
    }
}
