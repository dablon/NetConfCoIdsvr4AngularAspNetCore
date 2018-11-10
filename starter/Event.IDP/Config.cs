using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Event.IDP
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("event-api", "Events API"),
                new ApiResource("otherAPI", "otherAPI"),
                new ApiResource
                {
                    Name = "api2",

                    // secret for using introspection endpoint
                    ApiSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // include the following using claims in access token (in addition to subject id)
                    UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Email },

                    // this API defines two scopes
                    Scopes =
                    {
                        new Scope()
                        {
                            Name = "api2.full_access",
                            DisplayName = "Full access to API 2",
                        },
                        new Scope
                        {
                            Name = "api2.read_only",
                            DisplayName = "Read only access to API 2"
                        }
                    }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "d860efca-22d9-47fd-8249-791ba61b07c7",
                    Username = "juan",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Frank"),
                        new Claim("family_name", "Underwood"),
                        new Claim("address", "Main Road 1"),
                        new Claim("role", "Administrator"),
                        new Claim("subscriptionlevel", "FreeUser"),
                        new Claim("country", "nl")
                    }
                },
                new TestUser
                {
                    SubjectId = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                    Username = "diego",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Claire"),
                        new Claim("family_name", "Underwood"),
                        new Claim("address", "Big Street 2"),
                        new Claim("role", "Doctor"),
                        new Claim("subscriptionlevel", "PayingUser"),
                        new Claim("country", "be")
                    }
                }
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "eventweb",
                    ClientName = "Event Web",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,

                    RedirectUris =new List<string>
                    {
                        "https://localhost:4200/signin-oidc",
                        "https://localhost:4200/redirect-silentrenew"
                    },
                    AllowedCorsOrigins =     { "https://localhost:4200/" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "event-api",
                        "roles",
                    },
                    //IdentityTokenLifetime=120,
                    //AccessTokenLifetime=120

                },
                new Client
                {
                    ClientId = "consoleclient",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = {"api2.read_only" }
                },
                new Client
                {
                    ClientId = "consolewithcredentials",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "projects-api" }
                },
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris           = { "https://localhost:4201/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:4201/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    AllowOfflineAccess = true

                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", "Your role(s)", new []{"role"}),
            };
        }
    }
}
