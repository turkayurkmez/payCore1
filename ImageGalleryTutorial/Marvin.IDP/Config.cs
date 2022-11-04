using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Marvin.IDP
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
                {
                   new ApiScope("imagegalleryapi.fullaccess"),



                };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("imagalleryapi","Image Gallery API")
                {
                   // Scopes = { "imagegalleryapi.fullaccess" }
                }
            };



        public static IEnumerable<Client> Clients =>
            new Client[]
                {
                    new Client()
                    {
                        ClientName="Image Gallery",
                        ClientId = "imagegalleryclient",
                        AllowedGrantTypes = GrantTypes.Code,
                        RedirectUris = {"https://localhost:7184/signin-oidc" },
                        AllowedScopes =
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            IdentityServerConstants.StandardScopes.Address,
                            "imagegalleryapi.fullaccess"
                        },
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        RequireConsent = true, //DİKKAT!!! :)
                    }
                };
    }
}