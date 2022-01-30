using AutoMapper;
using SchoolApp.Business.Services.Commands.Interfaces;
using SchoolApp.Business.Services.Queries.Interfaces;
using SchoolApp.Infrastructure.Models.Classes;
using Infrastructure.Models.MapObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SchoolApp.Client.RealTime.Hubs.Interface;
using System.Net;
using SchoolApp.Client.Extensions.Logging;
using SchoolApp.Infrastructure.Models.MapObjects;

namespace SchoolApp.Client.GenericController;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class GenericController<TEntity, TEntityViewModel> : ControllerBase
        where TEntity : Entity
        where TEntityViewModel : Entity
{
    #region ATTRIBUTES
    protected readonly IGenericQueryService<TEntity> _genericQueryService;
    protected readonly IGenericCommandService<TEntity> _genericCommandService;
    protected readonly IMapper _mapper;
    protected readonly IRealTimeHub _realTimeHub;
    protected readonly ILogger<GenericController<TEntity, TEntityViewModel>> _logger;
    protected readonly IHostEnvironment _currentEnvironment;
    #endregion

    #region CONTRUCTOR
    public GenericController(
        IGenericQueryService<TEntity> genericQueryServic,
        IGenericCommandService<TEntity> genericCommandService,
        IMapper mapper,
        IRealTimeHub realTimeHub,
        ILogger<GenericController<TEntity, TEntityViewModel>> logger,
        IHostEnvironment currentEnvironment)
    {
        _genericQueryService = genericQueryServic;
        _genericCommandService = genericCommandService;
        _mapper = mapper;
        _realTimeHub = realTimeHub;
        _logger = logger;
        _currentEnvironment = currentEnvironment;
    }
    #endregion

    #region READ
    [HttpGet]
    public virtual async Task<IActionResult> Get()
    {
        var list = await _genericQueryService.GetAllTEntitys();
        if (list == null)
        {
            return NotFound(new
            {
                Message = "List not found !",
                StatusCode = (int)HttpStatusCode.NotFound + " - " + HttpStatusCode.NotFound.ToString()
            });
        }
        return Ok(_mapper.Map<IList<TEntityViewModel>>(list));
    }

    [Route("GetAll")]
    [HttpPost]
    public virtual async Task<IActionResult> Get(Filter filter)
    {
        var list = await _genericQueryService.GetTEntitys(orderBy: q => q.OrderByDescending(l => l.id),
            disableTracking: filter.disableTracking, take: filter.take,
            offset: filter.offset, includes: filter.includes);
        if (list == null)
        {
            return NotFound(new
            {
                Message = "List not found !",
                StatusCode = (int)HttpStatusCode.NotFound + " - " + HttpStatusCode.NotFound.ToString()
            });
        }
        return Ok(_mapper.Map<IList<TEntityViewModel>>(list));
    }

    [Route("GetByFilter")]
    [HttpPost]
    public virtual async Task<IActionResult> GetByFilter(Filter filter)
    {
        var filterTrimedLowered = filter.value.Trim().ToLower();
        bool isParsable = int.TryParse(filterTrimedLowered, out int filteredInt);
        IList<TEntity> list;
        if (isParsable)
        {
            list = await _genericQueryService.GetTEntitys(predicate: q => q.id == filteredInt,
                orderBy: q => q.OrderByDescending(o => o.id),
                disableTracking: filter.disableTracking, take: filter.take, offset: filter.offset, includes: filter.includes);
        }
        else
        {
            list = await _genericQueryService.GetTEntitys(
                predicate: q => q.createdby.Contains(filterTrimedLowered) ||
                q.updatedby.Contains(filterTrimedLowered) ||
                q.createdate.ToString().Contains(filterTrimedLowered) ||
                q.updatedate.ToString().Contains(filterTrimedLowered),
                orderBy: q => q.OrderByDescending(c => c.id),
                disableTracking: filter.disableTracking, take: filter.take, offset: filter.offset, includes: filter.includes);
        }
        if (list == null)
        {
            return NotFound(new
            {
                Message = "List not found !",
                StatusCode = (int)HttpStatusCode.NotFound + " - " + HttpStatusCode.NotFound.ToString()
            });
        }
        return Ok(_mapper.Map<IList<TEntityViewModel>>(list));
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> Get(int id)
    {
        var row = await _genericQueryService.GetTEntityById(id);
        if (row == null)
        {
            _logger.LoggingMessageWarning("SchoolApp", (int)HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["action"].ToString() + "ById", $"{id}", _currentEnvironment.ContentRootPath);
            return NotFound(new
            {
                Message = "Item not found !",
                StatusCode = (int)HttpStatusCode.NotFound + " - " + HttpStatusCode.NotFound.ToString()
            });
        }
        return Ok(_mapper.Map<TEntityViewModel>(row));
    }

    [Route("GetFirstByFilter")]
    [HttpPost]
    public virtual async Task<IActionResult> GetFirstByFilter(Filter filter)
    {
        var filterTrimedLowered = filter.value.Trim().ToLower();
        bool isParsable = int.TryParse(filterTrimedLowered, out int filteredInt);
        TEntity row;
        if (isParsable)
        {
            row = await _genericQueryService.GetFirstOrDefaultTEntity(predicate: q => q.id == filteredInt,
            disableTracking: filter.disableTracking, includes: filter.includes);
        }
        else
        {
            row = await _genericQueryService.GetFirstOrDefaultTEntity(
                predicate: q => q.createdby.Contains(filterTrimedLowered) ||
                q.updatedby.Contains(filterTrimedLowered) ||
                q.createdate.ToString().Contains(filterTrimedLowered) ||
                q.updatedate.ToString().Contains(filterTrimedLowered),
                disableTracking: filter.disableTracking, includes: filter.includes);
        }
        if (row == null)
        {
            return NotFound(new
            {
                Message = "Item not found !",
                StatusCode = (int)HttpStatusCode.NotFound + " - " + HttpStatusCode.NotFound.ToString()
            });
        }
        return Ok(_mapper.Map<TEntityViewModel>(row));
    }

    [Route("GetFromSql")]
    [HttpPost]
    public virtual async Task<IActionResult> GetFromSqlRaw(QueryParams queryParams)
    {
        await Task.Delay(0);
        return Ok();
    }
    #endregion

    #region ADD
    [HttpPost]
    public virtual async Task<IActionResult> Post(TEntity entity)
    {
        try
        {
            var row = await _genericCommandService.InsertTEntity(entity);
            var mapperRow = _mapper.Map<TEntityViewModel>(row);
            var mappedRowList = new object[]
            {
                    mapperRow
            };
            await _realTimeHub.SendToAll(mappedRowList);
            return Ok(new
            {
                Entity = mapperRow,
                Message = "Successfully added !"
            });
        }
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - Add", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Add failed !",
                Exception = ex.Message,
                ex.InnerException
            });
        }
    }

    [Route("AddRange")]
    [HttpPost]
    public virtual async Task<IActionResult> Post(IList<TEntity> entities)
    {
        try
        {
            var list = await _genericCommandService.InsertTEntity(entities);
            var mappedList = _mapper.Map<IList<TEntityViewModel>>(list);
            var objectMappedList = _mapper.Map<object[]>(mappedList);
            await _realTimeHub.SendToAll(objectMappedList);
            return Ok(new
            {
                Entities = mappedList,
                Message = "Successfully added !"
            });
        }
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - AddRange", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Add range failed !",
                Exception = ex.Message,
                ex.InnerException
            });
        }
    }
    #endregion

    #region UPDATE
    [Route("UpdateByState")]
    [HttpPut]
    public virtual IActionResult UpdateByStateTEntity(TEntity entity)
    {
        try
        {
            var row = _genericCommandService.UpdateByStateTEntity(entity);
            return Ok(new
            {
                Entity = _mapper.Map<TEntityViewModel>(row),
                Message = "Successfully updated !"
            });
        }
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - UpdateByState", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Update failed !",
                Exception = ex.Message,
                ex.InnerException
            });
        }
    }

    [HttpPut]
    public virtual IActionResult Put(TEntity entity)
    {
        try
        {
            var row = _genericCommandService.UpdateTEntity(entity);
            return Ok(new
            {
                Entity = _mapper.Map<TEntityViewModel>(row),
                Message = "Successfully updated !"
            });
        }
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - Update", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Update failed !",
                Exception = ex.Message,
                ex.InnerException
            });
        }
    }
    [Route("UpdateRange")]
    [HttpPut]
    public virtual IActionResult Put(IList<TEntity> entities)
    {
        try
        {
            var list = _genericCommandService.UpdateTEntity(entities);
            return Ok(new
            {
                Entities = _mapper.Map<IList<TEntityViewModel>>(list),
                Message = "Successfully updated !"
            });
        }
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - UpdateRange", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Update range failed !",
                Exception = ex.Message,
                ex.InnerException
            });
        }
    }

    [Route("UpdateRangeByState")]
    [HttpPut]
    public virtual async Task<IActionResult> UpdateByStateTEntity(IList<TEntity> entities)
    {
        try
        {
            var list = await _genericCommandService.UpdateByStateTEntity(entities);
            return Ok(new
            {
                Entity = _mapper.Map<IList<TEntityViewModel>>(list),
                Message = "Successfully updated !"
            });
        }
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - UpdateRangeByState", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Update failed !",
                Exception = ex.Message,
                ex.InnerException
            });
        }
    }
    #endregion

    #region DELETE
    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _genericCommandService.DeleteTEntity(id);
            return Ok(new
            {
                Message = "Successfully deleted !"
            });
        }
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - Delete", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Delete failed !",
                Exception = ex.Message,
                ex.InnerException
            });
        }
    }
    [Route("Delete")]
    [HttpPost]
    public virtual IActionResult Delete(TEntity entity)
    {
        try
        {
            _genericCommandService.DeleteTEntity(entity);
            return Ok(new
            {
                Message = "Successfully deleted !"
            });
        }
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - Delete_HttpPost", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Delete failed !",
                Exception = ex.Message,
                ex.InnerException
            });
        }
    }
    [Route("DeleteRange")]
    [HttpPost]
    public virtual IActionResult Delete(IList<TEntity> entities)
    {
        try
        {
            _genericCommandService.DeleteTEntity(entities);
            return Ok(new
            {
                Message = "Successfully deleted !"
            });
        }
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - DeleteRange", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Delete Range failed !",
                Exception = ex.Message,
                ex.InnerException
            });
        }
    }
    #endregion

    #region OTHER
    [Route("EntityExist")]
    [HttpPost]
    public virtual async Task<IActionResult> TEntitysExist(QueryParams queryParams)
    {
        var exist = await _genericQueryService.TEntitysExist();
        return Ok(exist);
    }
    [Route("CountEntitys")]
    [HttpPost]
    public virtual async Task<IActionResult> CountTEntitys(QueryParams queryParams)
    {
        var count = await _genericQueryService.CountTEntitys();
        return Ok(count);
    }
    #endregion
}