using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using Pdbc.Idp.Common;

namespace Pdbc.Idp.Data
{
    public class IdpClients
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientId = Constants.ClientIdForOne,

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret(Constants.ClientSecretForOne.Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { Constants.ScopeForApiOne }
                },
                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = Constants.ClientIdForMvcTwo,
                    ClientSecrets =
                    {
                        new Secret(Constants.ClientSecretForMvcTwo.Sha256())
                    },

                    AllowedGrantTypes = GrantTypes.Code,
                    
                    // where to redirect to after login
                    RedirectUris = { $"{Constants.MvcTwoUrlSecure}/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { $"{Constants.MvcTwoUrlSecure}/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }


                //,
                //new Client
                //{
                //    ClientName = "Sample Web Client",
                //    ClientId = "samplewebclient",
                //    AllowedGrantTypes = GrantTypes.Hybrid,
                //    AccessTokenType = AccessTokenType.Reference,
                //    RequireConsent = false,
                //    AllowOfflineAccess = true,

                //    FrontChannelLogoutUri = "https://localhost:44318/Home/IDPTriggeredLogout",

                //    RedirectUris = new List<string>()
                //    {
                //        "https://localhost:44318/signin-oidc",
                //        "https://localhost:44319/signin-oidc"
                //    },
                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "sampleapi"
                //    },
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },

                //    PostLogoutRedirectUris =
                //    {
                //        "https://localhost:44318/signout-callback-oidc",
                //        "https://localhost:44319/signout-callback-oidc"
                //    }
                //},

                //new Client
                //{
                //    ClientName = "Sample User Agent Client",
                //    ClientId = "sampleuseragentclient",
                //    AllowedGrantTypes = GrantTypes.Implicit,
                //    AccessTokenType = AccessTokenType.Reference,
                //    AllowAccessTokensViaBrowser = true,
                //    RequireConsent = false,

                //    RedirectUris = new List<string>()
                //    {
                //        "https://localhost:4200/signin-oidc",
                //        "https://localhost:4200/redirect-silentrenew"
                //    },
                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "sampleapi"
                //    },
                //    PostLogoutRedirectUris =
                //    {
                //        "https://localhost:4200/"
                //    }
                //},
                //new Client
                //{
                //    ClientName = "Sample Token Exchange Client",
                //    ClientId = "sampletokenexchangeclient",
                //    AllowedGrantTypes = new[] { "urn:ietf:params:oauth:grant-type:token-exchange" },
                //    RequireConsent = false,

                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "samplesecondapi"
                //    },
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    }
                //}
            };
        }
    }
}