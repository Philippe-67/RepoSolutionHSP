using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace is2
{
    /// <summary>
    /// Definir une portee d'API
    /// </summary>
    public class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
       new List<ApiScope>
       {
            new ApiScope("apiRDV", "ServicePriseRDV")
       };
        public static IEnumerable<ApiResource> ApiResources =>
      new ApiResource[]
      {
      };
        public static IEnumerable<IdentityResource> IdentityResources =>
     new IdentityResource[]
     {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              new IdentityResources.Address(),
              new IdentityResources.Email(),
              new IdentityResource(
                  "roles",
                  "Your role(s)",
                  new List<string>() { "role" })
     };

        /// <summary>
        /// definir le client
        /// </summary>
        public static IEnumerable<Client> Clients =>
    new List<Client>
    {
        new Client
        {
                    ClientId = "client",
                    ClientName = "client UI",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RequirePkce = false,
                    AllowRememberConsent = false,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:5001/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:5001/signout-callback-oidc"
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Email,
                        "roles",
                        "rdvAPI"
                    }
         }

    };


    }
}
