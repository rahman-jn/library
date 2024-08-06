using Entities;
using libraryapi.Interfaces;

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
}