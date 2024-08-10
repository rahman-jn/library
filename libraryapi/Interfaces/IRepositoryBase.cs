using System.Linq.Expressions;

namespace libraryapi.Interfaces;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll();
    IQueryable<TResult> FindByCondition<TResult>(Expression<Func<T, bool>> expression, 
        Expression<Func<T, TResult>> selector, params Expression<Func<T, object>>[] includes);
}