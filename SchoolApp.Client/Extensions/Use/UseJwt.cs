using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoSchoolApp.Client.Extensions.Use
{
    public static class UseJwt
    {
        public static void UseJWT(this IApplicationBuilder self)
        {
            self.UseAuthentication();
        }
    }
}
