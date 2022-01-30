using SchoolApp.Business.Services.Commands.Interfaces;
using SchoolApp.Infrastructure.DatabaseContext;
using SchoolApp.Infrastructure.Models.Classes;
using SchoolApp.UnitOfWork.UnitOfWork.Interface;

namespace SchoolApp.Business.Services.Commands.Classes;
public class GenericCommandService<TEntity> : IGenericCommandService<TEntity> where TEntity : Entity
{
    #region ATTRIBUTES
    private IUnitOfWork<DatabaseContextSchool> _unitOfWork;
    #endregion

    #region CONSTRUCTOR
    public GenericCommandService(IUnitOfWork<DatabaseContextSchool> unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(unitOfWork));
    }
    #endregion

    #region ADD

    public async Task<TEntity> InsertTEntity(TEntity TEntity)
    {
        TEntity.createdate = DateTime.Now;
        await _unitOfWork.GetRepository<TEntity>().Add(TEntity);
        await _unitOfWork.Save();
        return TEntity;
    }

    public async Task<IList<TEntity>> InsertTEntity(IList<TEntity> TEntitys)
    {
        foreach (var TEntity in TEntitys)
        {
            TEntity.createdate = DateTime.Now;
        }
        await _unitOfWork.GetRepository<TEntity>().Add(TEntitys);
        await _unitOfWork.Save();
        return TEntitys;
    }
    #endregion

    #region UPDATE

    public TEntity UpdateByStateTEntity(TEntity TEntity)
    {
        TEntity.updatedate = DateTime.Now;
        _unitOfWork.GetRepository<TEntity>().UpdateByState(TEntity);
        _unitOfWork.Save();
        return TEntity;
    }

    public TEntity UpdateTEntity(TEntity TEntity)
    {
        TEntity.updatedate = DateTime.Now;
        _unitOfWork.GetRepository<TEntity>().Update(TEntity);
        _unitOfWork.Save();
        return TEntity;
    }

    public IList<TEntity> UpdateTEntity(IList<TEntity> TEntitys)
    {
        foreach (var TEntity in TEntitys)
        {
            TEntity.updatedate = DateTime.Now;
        }
        _unitOfWork.GetRepository<TEntity>().Update(TEntitys);
        _unitOfWork.Save();
        return TEntitys;
    }

    public async Task<IList<TEntity>> UpdateByStateTEntity(IList<TEntity> TEntitys)
    {
        await _unitOfWork.GetRepository<TEntity>().UpdateByState(TEntitys);
        return TEntitys;
    }
    #endregion

    #region DELETE

    public async Task DeleteTEntity(object id)
    {
        await _unitOfWork.GetRepository<TEntity>().Delete(id);
        await _unitOfWork.Save();
    }

    public void DeleteTEntity(TEntity TEntity)
    {
        _unitOfWork.GetRepository<TEntity>().Delete(TEntity);
        _unitOfWork.Save();
    }

    public void DeleteTEntity(IList<TEntity> TEntitys)
    {
        _unitOfWork.GetRepository<TEntity>().Delete(TEntitys);
        _unitOfWork.Save();
    }
    #endregion
}
