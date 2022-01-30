using AutoMapper;
using SchoolApp.Business.Services.Commands.Interfaces;
using SchoolApp.Business.Services.Queries.Interfaces;
using SchoolApp.Client.DtoModel.Models;
using SchoolApp.Client.GenericController;
using SchoolApp.Client.RealTime.Hubs.Interface;
using SchoolApp.Infrastructure.Models.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using SchoolApp.Client.Extensions.Logging;
using SchoolApp.Business.Services.UploadPhoto.Interface;

namespace SchoolApp.Client.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfessorController : GenericController<Professor, ProfessorViewModel>
{
    protected readonly IUploadPhotoService _uploadPhotoService;
    public ProfessorController(
        IGenericQueryService<Professor> genericQueryServic,
        IGenericCommandService<Professor> genericCommandService,
        IMapper mapper,
        IRealTimeHub realTimeHub,
        ILogger<GenericController<Professor, ProfessorViewModel>> logger,
        IHostEnvironment currentEnvironment,
        IUploadPhotoService uploadPhotoService): base(genericQueryServic, genericCommandService, mapper, realTimeHub, logger, currentEnvironment)
    {
        _uploadPhotoService = uploadPhotoService;
    }

    [Route("UploadPhotos")]
    [HttpPost]
    public async Task<IActionResult> UploadPhotoAsAsync(IList<IFormFile> photos)
    {
        try
        {
            await _uploadPhotoService.UploadPhotoAsAsync(photos, _currentEnvironment.ContentRootPath);
            return Ok(new
            {
                Message = "Successfully Uploaded !"
            });
        }
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - Upload", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Upload failed !"
            });
        }
    }
}