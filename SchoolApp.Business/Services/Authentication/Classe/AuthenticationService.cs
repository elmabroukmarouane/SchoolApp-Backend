using SchoolApp.Business.Services.Authentication.Interface;
using SchoolApp.Business.Services.Queries.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SchoolApp.Infrastructure.Models.Classes;
using SchoolApp.Infrastructure.Models.MapObjects;
using SchoolApp.Infrastructure.DatabaseContext.Seed.Data;
using SchoolApp.Business.Services.Commands.Interfaces;

namespace SchoolApp.Business.Services.Authentication.Classe;
public class AuthenticationService : IAuthenticationService
{
    #region ATTRIBUTE
    private readonly IGenericQueryService<User> _genericQueryService;
    private readonly IGenericCommandService<User> _genericCommandService;
    #endregion

    #region CONTRUCTOR
    public AuthenticationService(IGenericQueryService<User> genericQueryService, IGenericCommandService<User> genericCommandService)
    {
        _genericQueryService = genericQueryService;
        _genericCommandService = genericCommandService;
    }
    #endregion

    #region METHODS
    public async Task<User?> Authenticate(UserLogin UserLogin)
    {
        if (string.IsNullOrEmpty(UserLogin.Email) || string.IsNullOrEmpty(UserLogin.Password))
            return null;
        var AttempingUser = await _genericQueryService.GetFirstOrDefaultTEntity(
            predicate: u => u.email.Trim().ToLower().Equals(UserLogin.Email.Trim().ToLower()),
            includes: "role,person");
        if (AttempingUser == null)
        {
            return null;
        }
        var passwordHash = UserSeed.CreateHashPassword(UserLogin.Password.Trim());
        var passwordAuth = AttempingUser.password;
        if (passwordAuth.Equals(passwordHash))
        {
            AttempingUser.isOnline = true;
            _genericCommandService.UpdateTEntity(AttempingUser);
            return AttempingUser;
        }
        return null;
    }
    public async Task<bool> Logout(int id)
    {
        var LoggedUser = await _genericQueryService.GetTEntityById(id);
        if (LoggedUser == null)
        {
            return false;
        }
        LoggedUser.isOnline = false;
        _genericCommandService.UpdateTEntity(LoggedUser);
        return true;
    }

    public string CreateToken(User user, string keyString, string issuerString, string audienceString)
    {
        var claims = new[] {
                //new Claim(JwtRegisteredClaimNames.GivenName, user.customer.firstname + " " + user.customer.lastname),
                new Claim(JwtRegisteredClaimNames.GivenName, user.email),
                new Claim(JwtRegisteredClaimNames.Email, user.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                // new Claim(JwtRegisteredClaimNames.Iss, JsonConvert.SerializeObject(user))
            };
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(keyString));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var token = new JwtSecurityToken(
            issuer: issuerString,
            audience: audienceString,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    #endregion
}
