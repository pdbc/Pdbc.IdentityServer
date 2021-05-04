using System.Collections.Generic;
using IdentityServer4.Models;
using Pdbc.Idp.Common;

namespace Pdbc.Idp.Data
{
    public class IdpApiScopes
    {
        public static IEnumerable<ApiScope> GetScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope(Constants.ScopeForApiOne, "Scope for API One")
            };
        }
    }
}