﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;
namespace Data.Services.Identity
{
    public static class SD
    {
        public static string Admin = "Admin";
        public static string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources
            = new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Email(),
                    new IdentityResources.Profile()
                };
        public static IEnumerable<ApiScope> ApiScopes
            = new List<ApiScope> {
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
                    ClientId = "client",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read", "write", "profile"}
                },
                new Client
                {
                    ClientId = "data",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "http://localhost:44300/signin-oidc" },
                    PostLogoutRedirectUris = {"http://localhost:44300/signout-callback-oidc" },
                    AllowedScopes = new List<string>
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
