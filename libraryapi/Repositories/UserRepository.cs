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

    public UserDto GetUserAccount(User user)
    {
        // Step 1: Create the query
        var query = FindByCondition(
            usr => usr.Email.Equals(user.Email) && usr.Password.Equals(user.Password),
            usr => new UserDto
            {
                Email = usr.Email,
                FirstName = usr.FirstName,
                LastName = usr.LastName,
                Role = usr.Role
            },
            usr => usr.Role);  // Including the Role navigation property

        // Step 2: View the SQL query
        string sql = query.ToQueryString();
        Console.WriteLine(sql);  // Or log it using a logger

        // Step 3: Execute the query to get the result
        return query.FirstOrDefault();
    }



    
    public IEnumerable<User> GetAllUsers()
    {
        return FindAll().ToList();
    }
    public User AuthenticateUser(string userName, string password)
    {
        throw new NotImplementedException();
    }
}