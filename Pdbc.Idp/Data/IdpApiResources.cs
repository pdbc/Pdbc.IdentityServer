using System.Collections.Generic;
using IdentityServer4.Models;

namespace Pdbc.Idp.Data
{
    public class IdpApiResources
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("name", "Display Name",
                    new string [] {"given_name", "family_name", "email"}),

                // api secret for reference token
                new ApiResource("name 2", "Display Name 2",
                    new string [] {"given_name", "family_name", "email"})
                {
                    ApiSecrets = { new Secret("secureSecret".Sha256()) }
                }
            };
        }
    }
}