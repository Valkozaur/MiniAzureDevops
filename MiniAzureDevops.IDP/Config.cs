using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MiniAzureDevops.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            { 
                new Client()
                {
                    ClientName = "MiniAzureDevops.ItemTable",
                    ClientId= "miniazuredevopsclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new string[]
                    {
                        "https://localhost:5001/singin-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
    }
}