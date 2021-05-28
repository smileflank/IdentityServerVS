using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace IdentityServerCenter
{

    public class Config
    {
        public static IEnumerable<ApiResource> GetResource()
        {
            return new List<ApiResource>
            {
                new ApiResource("configs","My Api")
                {
                    Scopes ={ "configs" }
                }
            };
        }
        public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("configs")
        };

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>{
                new Client(){
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets={ new Secret("secret".Sha256())},
                    ClientId="client",
                    AllowedScopes=
                    {
                        "configs"
                    }

                }
            };
        }


    }
}
