using System.Linq.Expressions;
using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Business.Services.Queries.Interfaces;
public interface IGenericQueryService<TEntity> where TEntity : Entity
{
    #region READ
    Task<IList<TEntity>> GetAllTEntitys();
    Task<IList<TEntity>> GetTEntitys(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includes = "",
        bool disableTracking = true,
        int take = 0, int offset = 0);
    Task<TEntity> GetTEntityById(object id);
    Task<TEntity> GetFirstOrDefaultTEntity(
        Expression<Func<TEntity, bool>>? predicate = null,
        string includes = "",
        bool disableTracking = true);
    // Task<IList<TEntity>> GetFromSqlRaw(string sql,
    //     params object[] parameters);
    Task<IList<TEntity>> GetFromSqlRaw(string sql);
    #endregion

    #region OTHER
    Task<int> CountTEntitys(Expression<Func<TEntity, bool>>? predicate = null);
    Task<bool> TEntitysExist(Expression<Func<TEntity, bool>>? predicate = null);
    #endregion
}