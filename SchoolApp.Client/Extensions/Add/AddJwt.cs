﻿// using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SchoSchoolApp.Client.Extensions.Add
{
    public static class AddJwt
    {
        public static void AddJWT(this IServiceCollection self, IConfiguration configuration)
        {
            // self.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //     .AddJwtBearer(options =>
            //     {
            //         options.TokenValidationParameters = new TokenValidationParameters
            //         {
            //             ValidateIssuer = true,
            //             ValidateAudience = true,
            //             ValidateLifetime = true,
            //             ValidateIssuerSigningKey = true,
            //             ValidIssuer = configuration.GetSection("Jwt").GetSection("Issuer").Value,
            //             ValidAudience = configuration.GetSection("Jwt").GetSection("Audience").Value,
            //             IssuerSigningKey = new SymmetricSecurityKey(
            //                                             Encoding.UTF8.GetBytes(
            //                                                 configuration.GetSection("Jwt").GetSection("Key").Value))
            //         };
            //     });
        }
    }
}
