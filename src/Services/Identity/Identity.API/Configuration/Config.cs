using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Microsoft.ExxaTechServices.Services.Identity.API.Configuration
{
    public class Config
    {
        // ApiResources define the apis in your system
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("zipcode", "ZipCode Service"),
                new ApiResource("marketing", "Marketing Service"),
                new ApiResource("mobileexxatechagg", "Mobile ExxaTech Aggregator"),
                new ApiResource("webexxatechagg", "Web ExxaTech Aggregator")
            };
        }
        
        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        // client want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients(Dictionary<string,string> clientsUrl)
        {
            return new List<Client>
            {
                // JavaScript Client
                new Client
                {
                    ClientId = "js",
                    ClientName = "ExxaTech SPA OpenId Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =           { $"{clientsUrl["Spa"]}/" },
                    RequireConsent = false,
                    PostLogoutRedirectUris = { $"{clientsUrl["Spa"]}/" },
                    AllowedCorsOrigins =     { $"{clientsUrl["Spa"]}" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,                        
                        "zipcode",                        
                        "marketing",
                        "webexxatechagg"
                    }
                },
                new Client
                {
                    ClientId = "xamarin",
                    ClientName = "ExxaTech Xamarin OpenId Client",
                    AllowedGrantTypes = GrantTypes.Hybrid,                    
                    //Used to retrieve the access token on the back channel.
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RedirectUris = { clientsUrl["Xamarin"] },
                    RequireConsent = false,
                    RequirePkce = true,
                    PostLogoutRedirectUris = { $"{clientsUrl["Xamarin"]}/Account/Redirecting" },
                    AllowedCorsOrigins = { "http://exxatechxamarin" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,                        
                        "zipcode",
                        "marketing",
                        "mobileexxatechagg"
                    },
                    //Allow requesting refresh tokens for long lived API access
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true
                },
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientUri = $"{clientsUrl["Mvc"]}",                             // public uri of the client
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = false,
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RedirectUris = new List<string>
                    {
                        $"{clientsUrl["Mvc"]}/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientsUrl["Mvc"]}/signout-callback-oidc"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "zipcode",
                        "marketing",
                        "webexxatechagg"
                    },
                },
                new Client
                {
                    ClientId = "mvctest",
                    ClientName = "MVC Client Test",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientUri = $"{clientsUrl["Mvc"]}",                             // public uri of the client
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    RedirectUris = new List<string>
                    {
                        $"{clientsUrl["Mvc"]}/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientsUrl["Mvc"]}/signout-callback-oidc"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "zipcode",
                        "marketing",
                        "webexxatechagg"
                    },
                },
                new Client
                {
                    ClientId = "zipcodeswaggerui",
                    ClientName = "ZipCode Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{clientsUrl["ZipCodeApi"]}/swagger/o2c.html" },
                    PostLogoutRedirectUris = { $"{clientsUrl["ZipCodeApi"]}/swagger/" },

                    AllowedScopes =
                    {
                        "zipcode"
                    }
                },
                new Client
                {
                    ClientId = "marketingswaggerui",
                    ClientName = "Marketing Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{clientsUrl["MarketingApi"]}/swagger/o2c.html" },
                    PostLogoutRedirectUris = { $"{clientsUrl["MarketingApi"]}/swagger/" },

                    AllowedScopes =
                    {
                        "marketing"
                    }
                },                                
                new Client
                {
                    ClientId = "mobileexxatechswaggerui",
                    ClientName = "Mobile ExxaTech Aggregattor Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{clientsUrl["MobileExxaTechAgg"]}/swagger/o2c.html" },
                    PostLogoutRedirectUris = { $"{clientsUrl["MobileExxaTechAgg"]}/swagger/" },

                    AllowedScopes =
                    {
                        "mobileexxatechagg"
                    }
                },
                new Client
                {
                    ClientId = "webexxatechaggswaggerui",
                    ClientName = "Web ExxaTech Aggregattor Swagger UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { $"{clientsUrl["WebShoppingAgg"]}/swagger/o2c.html" },
                    PostLogoutRedirectUris = { $"{clientsUrl["WebShoppingAgg"]}/swagger/" },

                    AllowedScopes =
                    {
                        "webexxatechagg"
                    }
                }

            };
        }
    }
}