using Entities;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;

namespace libraryapi.Repositories;

public class UserBookRepository :  RepositoryBase<UserBook>, IUserBookRepository
{
    public UserBookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }

    public void CreateUserBook(UserBook userBook)
    {
        Create(userBook);
    }
}