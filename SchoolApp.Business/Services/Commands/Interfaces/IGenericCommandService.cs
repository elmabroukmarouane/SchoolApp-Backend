using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Business.Services.Commands.Interfaces;
public interface IGenericCommandService<TEntity> where TEntity : Entity
{
    #region CREATE
    Task<TEntity> InsertTEntity(TEntity TEntity);
    Task<IList<TEntity>> InsertTEntity(IList<TEntity> TEntitys);
    #endregion

    #region UPDATE
    TEntity UpdateTEntity(TEntity TEntity);
    TEntity UpdateByStateTEntity(TEntity TEntity);
    IList<TEntity> UpdateTEntity(IList<TEntity> TEntitys);
    Task<IList<TEntity>> UpdateByStateTEntity(IList<TEntity> TEntitys);
    #endregion

    #region DELETE
    Task DeleteTEntity(object id);
    void DeleteTEntity(TEntity TEntity);
    void DeleteTEntity(IList<TEntity> TEntitys);
    #endregion
}
