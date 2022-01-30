using System.Diagnostics;
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
        try
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
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - Get()", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Get failed !"
            });
        }
    }

    [Route("GetAll")]
    [HttpPost]
    public virtual async Task<IActionResult> Get(Filter filter)
    {
        try
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
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - Get(filter)", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Get failed !"
            });
        }
    }

    [Route("GetByFilter")]
    [HttpPost]
    public virtual async Task<IActionResult> GetByFilter(Filter filter)
    {
        try
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
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - GetByFilter(filter)", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Get failed !"
            });
        }
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> Get(int id)
    {
        try
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
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - Get(id)", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Get failed !"
            });
        }
    }

    [Route("GetFirstByFilter")]
    [HttpPost]
    public virtual async Task<IActionResult> GetFirstByFilter(Filter filter)
    {
        try
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
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - GetFirstByFilter(filter)", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Get failed !"
            });
        }
    }

    [Route("GetFromSql")]
    [HttpPost]
    public virtual async Task<IActionResult> GetFromSqlRaw(QueryParams queryParams)
    {
        try
        {
            var sql = $"SELECT { queryParams.fields } FROM { queryParams.table }"; // For the moment in .NET 6 (30/01/2022) There are a few limitations to be aware of when using raw SQL queries, so The SQL query must return data for all properties of the entity type Therefore, currently, we are not allowed to specify columns using FromSqlRaw
            if (!string.IsNullOrEmpty(queryParams.where)) sql += $" WHERE { queryParams.where }";
            if (!string.IsNullOrEmpty(queryParams.groupby)) sql += $" GROUP BY { queryParams.groupby }";
            if (!string.IsNullOrEmpty(queryParams.having)) sql += $" HAVING { queryParams.having }";
            if (!string.IsNullOrEmpty(queryParams.orderby)) sql += $" ORDER BY { queryParams.orderby }";
            /* {
                "fields": "*" or "id, firstname, lastname, birthdate, createdate, updatedate, createdby, updatedby"<ALL_FIELDS_EXPLICITLY>,
                "table": "persons",
                "where": "",
                "groupby": "id, firstname, lastname, birthdate, createdate, updatedate, createdby, updatedby",
                "having": "sum(id) > 1",
                "orderby": "id desc",
                "limit": 2,
                "offset": 2
                } */ // Request Swagger
            var list = await _genericQueryService.GetFromSqlRaw(sql);
            if (!string.IsNullOrEmpty(queryParams.limit.ToString()) && int.TryParse(queryParams.limit.ToString(), out int LimitIsInt) && queryParams.limit > 0)
                list = list.Skip(queryParams.limit).ToList();
            if (!string.IsNullOrEmpty(queryParams.offset.ToString()) && int.TryParse(queryParams.offset.ToString(), out int OffsetIsInt) && queryParams.offset > 0)
                list = list.Take(queryParams.offset).ToList();
            if (list == null)
            {
                return NotFound(new
                {
                    Message = "Item not found !",
                    StatusCode = (int)HttpStatusCode.NotFound + " - " + HttpStatusCode.NotFound.ToString()
                });
            }
            return Ok(list);
        }
        catch (Exception ex)
        {
            _logger.LoggingMessageError("SchoolApp", (int)HttpStatusCode.InternalServerError, HttpStatusCode.InternalServerError.ToString(), HttpContext.Request.Method, ControllerContext.RouteData.Values["controller"].ToString(), ControllerContext.RouteData.Values["controller"].ToString() + " - GetFromSqlRaw(queryParams)", ex, _currentEnvironment.ContentRootPath);
            return StatusCode(500, new
            {
                Message = "Get failed !"
            });
        }
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
                Message = "Add failed !"
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
                Message = "Add range failed !"
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
                Message = "Update failed !"
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
                Message = "Update failed !"
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
                Message = "Update range failed !"
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
                Message = "Update failed !"
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
                Message = "Delete failed !"
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
                Message = "Delete failed !"
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
                Message = "Delete Range failed !"
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