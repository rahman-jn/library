using Entities;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;

namespace libraryapi.Repositories;

public class UserRepository : RepositoryBase<User> , IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }

    public User AuthenticateUser(string userName, string password)
    {
        throw new NotImplementedException();
    }
}