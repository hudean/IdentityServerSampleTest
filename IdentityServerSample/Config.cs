using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServerSample
{
    public class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope("api1", "My API")
         };

        public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            //客户端模式 / 最简单的
            new Client
            {
                 ClientId = "client",
                
                 // no interactive user, use the clientid/secret for authentication
                 AllowedGrantTypes = GrantTypes.ClientCredentials,
                
                 // secret for authentication
                 ClientSecrets =
                 {
                     new Secret("secret".Sha256())
                 },
                
                 // scopes that client has access to
                 AllowedScopes = { "api1" }
            },
            //密码模式
             new Client
            {
                 ClientId = "pwdClient",
                
                 // no interactive user, use the clientid/secret for authentication
                 AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                
                 // secret for authentication
                 ClientSecrets =
                 {
                     new Secret("secret".Sha256())
                 },
                
                 //服务端可以设置 不需要RequiredClientSecret
                 //RequireClientSecret=false,
                 // scopes that client has access to
                 AllowedScopes = { "api1" }
            }
             , 
             // interactive ASP.NET Core MVC client
             new Client
             {
                 ClientId = "mvc",
                 ClientSecrets = { new Secret("secret".Sha256()) },
            
                 AllowedGrantTypes = GrantTypes.Code,
            
                 // where to redirect to after login
                 RedirectUris = { "https://localhost:5002/signin-oidc" },
            
                 // where to redirect to after logout
                 PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
            
                 AllowedScopes = new List<string>
                 {
                     IdentityServerConstants.StandardScopes.OpenId,
                     IdentityServerConstants.StandardScopes.Profile
                 }
             }
        };


        public static IEnumerable<TestUser> TestUsers =>
        new List<TestUser>()
        {
            new TestUser ()
            {
                 SubjectId="1",
                 Username="hda",
                 Password="123456"
            }
        };


        public static IEnumerable<IdentityResource> IdentityResources =>
    new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
    };
    }
}