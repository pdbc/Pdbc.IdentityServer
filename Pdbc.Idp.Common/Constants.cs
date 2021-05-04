using System;

namespace Pdbc.Idp.Common
{
    public static class Constants
    {
        public const string AuthorityUrl = "https://localhost:5001";

        // Client One (Client Credentials sample)
        public const String ClientIdForOne = "ClientIdForOne";
        public const String ClientSecretForOne = "ClientSecretForOne";

        // Api One (Client Credentials sample)
        public const String ApiOneUrl = "http://localhost:6001";
        public const String ApiOneUrlSecure = "https://localhost:44301";

        public const String ScopeForApiOne = "ScopeForApiOne";
    }
}
