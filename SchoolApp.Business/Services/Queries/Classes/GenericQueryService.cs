using SchoolApp.Business.Services.Queries.Interfaces;
using SchoolApp.Infrastructure.DatabaseContext;
using SchoolApp.Infrastructure.Models.Classes;
using SchoolApp.UnitOfWork.UnitOfWork.Interface;
using System.Linq.Expressions;

namespace SchoolApp.Business.Services.Queries.Classes;
public class GenericQueryService<TEntity> : IGenericQueryService<TEntity> where TEntity : Entity
{
    #region ATTRIBUTES
    private IUnitOfWork<DatabaseContextSchool> _unitOfWork;
    #endregion

    #region CONSTRUCTOR
    public GenericQueryService(IUnitOfWork<DatabaseContextSchool> unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(unitOfWork));
    }
    #endregion

    #region READ
    public async Task<IList<TEntity>> GetAllTEntitys()
    {
        return await _unitOfWork.GetRepository<TEntity>().GetAll();
    }

    public async Task<IList<TEntity>> GetTEntitys(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includes = "", bool disableTracking = true,
        int take = 0, int offset = 0)
    {
        return await _unitOfWork.GetRepository<TEntity>().GetMuliple(
            predicate: predicate, orderBy: orderBy,
            includes: includes, disableTracking: disableTracking,
            take: take, offset: offset);
    }

    public async Task<TEntity> GetTEntityById(object id)
    {
        return await _unitOfWork.GetRepository<TEntity>().GetById(id);
    }

    public async Task<TEntity> GetFirstOrDefaultTEntity(
        Expression<Func<TEntity, bool>>? predicate = null,
        string includes = "", bool disableTracking = true)
    {
        return await _unitOfWork.GetRepository<TEntity>().GetFirstOrDefault(
            predicate: predicate, includes: includes,
            disableTracking: disableTracking);
    }

    // public Task<IList<TEntity>> GetFromSqlRaw(
    //     string sql, params object[] parameters)
    // {
    //     return _unitOfWork.GetRepository<TEntity>().FromSqlRaw(sql: sql, parameters: parameters);
    // }
    public Task<IList<TEntity>> GetFromSqlRaw(
        string sql)
    {
        return _unitOfWork.GetRepository<TEntity>().FromSqlRaw(sql: sql);
    }
    #endregion

    #region OTHER
    public async Task<bool> TEntitysExist(Expression<Func<TEntity, bool>> predicate = null)
    {
        return await _unitOfWork.GetRepository<TEntity>().Exists(predicate: predicate);
    }

    public async Task<int> CountTEntitys(Expression<Func<TEntity, bool>> predicate = null)
    {
        return await _unitOfWork.GetRepository<TEntity>().Count(predicate: predicate);
    }
    #endregion
}
