using Microsoft.EntityFrameworkCore;
using SchoolApp.Domain.GenericRepository.Interface;
using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.UnitOfWork.UnitOfWork.Interface;
public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
{
    TContext DbContext { get; }
    IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity;
    Task<int> Save();
}
