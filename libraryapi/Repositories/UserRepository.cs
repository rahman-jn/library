using Entities;
using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace libraryapi.Repositories;

public class UserRepository : RepositoryBase<User> , IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }

    public UserDto GetUserById(int userId)
    {
        return FindByCondition(
            usr => usr.Id.Equals(userId),
            usr => new UserDto
            {
                Email = usr.Email,
                FirstName = usr.FirstName,
                LastName = usr.LastName,
                Role = usr.Role
            }
            ).FirstOrDefault();
    }
    public IEnumerable<User> GetAllUsers()
    {
        return FindAll().ToList();
    }

    public void CreateUser(User user)
    {
        Create(user);
    }
}