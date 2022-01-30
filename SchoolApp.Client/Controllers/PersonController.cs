using AutoMapper;
using SchoolApp.Business.Services.Commands.Interfaces;
using SchoolApp.Business.Services.Queries.Interfaces;
using SchoolApp.Client.DtoModel.Models;
using SchoolApp.Client.GenericController;
using SchoolApp.Client.RealTime.Hubs.Interface;
using SchoolApp.Infrastructure.Models.Classes;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApp.Client.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : GenericController<Person, PersonViewModel>
{
    public PersonController(
        IGenericQueryService<Person> genericQueryServic,
        IGenericCommandService<Person> genericCommandService,
        IMapper mapper,
        IRealTimeHub realTimeHub,
        ILogger<GenericController<Person, PersonViewModel>> logger,
        IHostEnvironment currentEnvironment) : base(genericQueryServic, genericCommandService, mapper, realTimeHub, logger, currentEnvironment)
    { }
}