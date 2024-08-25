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
    
    public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includes)
    {
        var query = RepositoryContext.Set<T>().AsNoTracking();
        // Apply each include expression to the query
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return query;
    }

    public IQueryable<TResult> FindByCondition<TResult>(
        Expression<Func<T, bool>> expression,
        Expression<Func<T, TResult>> selector,
        params Expression<Func<T, object>>[] includes)
    {
        // Start with the base query
        var query = RepositoryContext.Set<T>()
            .Where(expression)
            .AsNoTracking();

        // Apply each include expression to the query
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        // Apply the selector for projection
        return query.Select(selector);
    }

    public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
}