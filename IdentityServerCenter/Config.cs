using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Test;

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

                },
                new Client()
                {
                    ClientId="pwdclient",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    ClientSecrets={ new Secret("secret".Sha256())},
                    AllowedScopes=
                    {
                        "configs"
                    }
                }
            };
        }

        /// <summary>
        /// 替换为数据库读取
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TestUser> GetTestUser()
        {
            return new List<TestUser>() { new TestUser(){
                SubjectId="1",
                Username="jesse",
                Password="123456"

            },
            new TestUser(){
                SubjectId="2",
                Username="admin",
                Password="123456"

            }
            };

        }


    }
}
