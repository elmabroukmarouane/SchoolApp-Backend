using AutoMapper;
using SchoolApp.Business.Services.Commands.Interfaces;
using SchoolApp.Business.Services.Queries.Interfaces;
using SchoolApp.Client.DtoModel.Models;
using SchoolApp.Client.GenericController;
using SchoolApp.Client.RealTime.Hubs.Interface;
using SchoolApp.Infrastructure.Models.Classes;
using Microsoft.AspNetCore.Mvc;

namespace PokerPlanningApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : GenericController<User, UserViewModel>
{
    public UserController(
        IGenericQueryService<User> genericQueryServic,
        IGenericCommandService<User> genericCommandService,
        IMapper mapper,
        IRealTimeHub realTimeHub,
        ILogger<GenericController<User, UserViewModel>> logger,
        IHostEnvironment currentEnvironment) : base(genericQueryServic, genericCommandService, mapper, realTimeHub, logger, currentEnvironment)
    { }
}