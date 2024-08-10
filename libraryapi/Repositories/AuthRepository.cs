using Entities;
using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;

namespace libraryapi.Repositories;

public class AuthRepository :  RepositoryBase<User>, IAuthRepositiry
{
    public AuthRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
    
    public UserDto GetUserAccount(User user)
    {
        //Create the query
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

        //View the SQL query
        //string sql = query.ToQueryString();
        //Console.WriteLine(sql);  

        // Execute the query to get the result
        return query.FirstOrDefault();
    }
}