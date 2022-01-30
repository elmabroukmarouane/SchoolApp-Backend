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
public class ProfessorController : GenericController<Professor, ProfessorViewModel>
{
    public ProfessorController(
        IGenericQueryService<Professor> genericQueryServic,
        IGenericCommandService<Professor> genericCommandService,
        IMapper mapper,
        IRealTimeHub realTimeHub,
        ILogger<GenericController<Professor, ProfessorViewModel>> logger,
        IHostEnvironment currentEnvironment) : base(genericQueryServic, genericCommandService, mapper, realTimeHub, logger, currentEnvironment)
    { }
}