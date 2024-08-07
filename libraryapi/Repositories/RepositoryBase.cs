using System.Linq.Expressions;
using Entities;
using libraryapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace libraryapi.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: class
{
    protected RepositoryContext RepositoryContext{ get; set;  }

    public RepositoryBase(RepositoryContext repositoryContext)
    {
        RepositoryContext = repositoryContext;
    }
    
    public IQueryable<T> FindAll()
    {
        throw new NotImplementedException();
    }
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
        RepositoryContext.Set<T>().Where(expression).AsNoTracking();
}