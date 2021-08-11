using System;
using Mc2.Wise.NetStandard.ClientProperties;

namespace Mc2.Wise.NetStandard.ClientExceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string error) : base ($"Server error code: {error}")
        {
            Error = error;
        }
        public string Error { get; }
    }
}