using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Test;

namespace Pdbc.Idp.Data
{
    public class IdpUsers
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "3DFAF108-7EA7-4667-945A-FA5239C9D7B6",
                    Username = "Patrick",
                    Password = "Password",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Patrick"),
                        new Claim("family_name", "De Boeck"),
                        new Claim("email", "patrick@test.com")
                    }
                },
                new TestUser
                {
                    SubjectId = "FFDC4532-4C3B-4824-9F72-18881E46C0C1",
                    Username = "Heidi",
                    Password = "Password",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Heidi"),
                        new Claim("family_name", "De Boeck"),
                        new Claim("email", "heidi@test.com")
                    }
                }
            };
        }

    }
}
