using System.Collections.Generic;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;
namespace Data.Services.Identity
{
    public static class SD
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
             new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Email(),
                    new IdentityResources.Profile()
                };
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope> {
                new ApiScope("data", "Data Server"),
                new ApiScope(name: "read", displayName: "Read you data."),
                new ApiScope(name: "write", displayName: "Write you data."),
                new ApiScope(name: "delete", displayName: "Delete you data."),
            };
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId="client",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes={"read", "write", "profile"}
                },
                new Client
                {
                    ClientId = "data",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris={ "https://localhost:7002/signin-oidc" },
                    PostLogoutRedirectUris={"https://localhost:7002/signout-callback-oidc" },
                    AllowedScopes=new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "data"
                    }
                }
            };                
    }
}
