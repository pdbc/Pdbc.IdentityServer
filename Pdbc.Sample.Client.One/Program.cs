using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Pdbc.Idp.Common;

namespace Pdbc.Sample.Client.One
{
    class Program
    {
        private static async Task Main()
        {
            // discover endpoints from metadata
            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync(Constants.AuthorityUrl);
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = Constants.ClientIdForOne,
                ClientSecret = Constants.ClientSecretForOne,
                Scope = Constants.ScopeForApiOne
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            // call api
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync($"{Constants.ApiOneUrlSecure}/identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                //Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
