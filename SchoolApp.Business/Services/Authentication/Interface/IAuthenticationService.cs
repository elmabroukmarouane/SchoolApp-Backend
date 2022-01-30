using SchoolApp.Infrastructure.Models.Classes;
using SchoolApp.Infrastructure.Models.MapObjects;

namespace SchoolApp.Business.Services.Authentication.Interface;
public interface IAuthenticationService
{
    Task<User> Authenticate(UserLogin UserLogin);
    string CreateToken(User user, string keyString, string issuerString, string audienceString);
}