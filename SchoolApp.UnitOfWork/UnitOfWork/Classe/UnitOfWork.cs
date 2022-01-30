﻿using SchoolApp.Domain.GenericRepository.Classe;
using SchoolApp.Domain.GenericRepository.Interface;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Infrastructure.Models.Classes;
using SchoolApp.UnitOfWork.UnitOfWork.Interface;

namespace SchoolApp.UnitOfWork.UnitOfWork.Classe;
public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
{
    public TContext DbContext { get; }
    private bool disposed = false;
    private Dictionary<Type, object>? _repositories;
    public UnitOfWork(TContext context) => DbContext = context ?? throw new ArgumentNullException(nameof(context));

    public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : Entity
    {
        if (_repositories == null)
        {
            _repositories = new Dictionary<Type, object>();
        }

        var type = typeof(TEntity);
        if (!_repositories.ContainsKey(type))
        {
            _repositories[type] = new GenericRepository<TEntity>(DbContext);
        }

        return (IGenericRepository<TEntity>)_repositories[type];
    }

    public async Task<int> Save()
    {
        return await DbContext.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                if (_repositories != null)
                {
                    _repositories.Clear();
                }
                DbContext.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
