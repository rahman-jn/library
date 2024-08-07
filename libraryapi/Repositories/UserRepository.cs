using Entities;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace libraryapi.Repositories;

public class UserRepository : RepositoryBase<User> , IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }

    public User GetUserAccount(User user)
    {
        return FindByCondition(usr => usr.Email.Equals(user.Email) && usr.Password.Equals(user.Password))
            .Include(ac => ac.Role)
            .FirstOrDefault();
    }
    public User AuthenticateUser(string userName, string password)
    {
        throw new NotImplementedException();
    }
}