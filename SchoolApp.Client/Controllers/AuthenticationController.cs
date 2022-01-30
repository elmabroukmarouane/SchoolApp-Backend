using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Business.Services.Authentication.Interface;
using SchoolApp.Client.DtoModel.Models;
using SchoolApp.Client.Extensions.Logging;
using SchoolApp.Infrastructure.Models.MapObjects;
using System.Net;

namespace SchoolApp.Client.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    protected readonly ILogger<AuthenticationController> _logger;
    protected readonly IHostEnvironment _currentEnvironment;

    public AuthenticationController(
        IAuthenticationService authenticationService,
        IConfiguration configuration,
        IMapper mapper,
        ILogger<AuthenticationController> logger,
        IHostEnvironment currentEnvironment)
    {
        _authenticationService = authenticationService;
        _configuration = configuration;
        _mapper = mapper;
        _logger = logger;
        _currentEnvironment = currentEnvironment;
    }

    [Route("Login")]
    [HttpPost]
    public async Task<IActionResult> Authenticate(UserLogin _user)
    {
        try
        {
            var user = await _authenticationService.Authenticate(_user);
            if (user == null)
            {
                return StatusCode(401, new
                {
                    Message = "Incorrect email or password"
                });
            }
            var token = _authenticationService.CreateToken(
                user,
                _configuration.GetSection("Jwt").GetSection("Key").Value,
                _configuration.GetSection("Jwt").GetSection("Issuer").Value,
                _configuration.GetSection("Jwt").GetSection("Audience").Value);
            return Ok(new
            {
                Message = "Hi " + user.person.firstname + " " + user.person.lastname + " !",
                User = _mapper.Map<UserViewModel>(user),
                Token = token,
            });
        }
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - Add", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Authentication failed !",
                Exception = ex.Message,
                ex.InnerException
            });
        }
    }
}