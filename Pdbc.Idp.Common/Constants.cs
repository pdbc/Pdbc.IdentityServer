using System;

namespace Pdbc.Idp.Common
{
    public static class Constants
    {
        public const string AuthorityUrl = "https://localhost:5001";

        // Api One
        public const String ApiOneUrl = "http://localhost:6001";
        public const String ApiOneUrlSecure = "https://localhost:44301";
        public const String ScopeForApiOne = "ScopeForApiOne";

        // Api Two
        public const String ApiTwoUrl = "http://localhost:6002";
        public const String ApiTwoUrlSecure = "https://localhost:44302";
        public const String ScopeForApiTwo = "ScopeForApiTwo";


        // Client One (Client Credentials sample)
        public const String ClientIdForOne = "ClientIdForOne";
        public const String ClientSecretForOne = "ClientSecretForOne";


        // Client Two (Mvc)
        public const String ClientIdForMvcTwo = "ClientIdForMvcTwo";
        public const string ClientSecretForMvcTwo = "ClientSecretForMvcTwo";
        public const String MvcTwoUrl = "http://localhost:6002";
        public const String MvcTwoUrlSecure = "https://localhost:44302";

    }
}
