using System.Collections.Generic;
using IdentityServer4.Models;

namespace Pdbc.Idp.Data
{
    public class IdpIdentityResources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }
    }
}