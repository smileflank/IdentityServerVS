using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;


namespace ThridPartyDemo
{
    class Program
    {
        private static HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
            }
            var sss = disco.TokenEndpoint;
            var tokenClient = new TokenClient(client, new TokenClientOptions() { 
            ClientId="client",ClientSecret="secret",Address=disco.TokenEndpoint});

            var tokenResponse = await tokenClient.RequestClientCredentialsTokenAsync("configs");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
            }

            Console.WriteLine(tokenResponse.Json);

            client.SetBearerToken(tokenResponse.AccessToken);
            var res= await client.GetAsync("http://localhost:5009/api/values");


            if(res.IsSuccessStatusCode)
            {
                Console.WriteLine(await res.Content.ReadAsStringAsync());
            }

            await Task.CompletedTask;
        }
    }
}
