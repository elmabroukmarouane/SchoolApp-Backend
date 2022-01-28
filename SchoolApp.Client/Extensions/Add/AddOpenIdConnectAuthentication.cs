using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
//using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace SchoSchoolApp.Client.Extensions.Add
{
    public static class AddOpenIdConnectAuthentication
    {
        public static void AddOpenIdConnectAuth(this IServiceCollection self, IConfiguration configuration)
        {
            
        }
    }
}
