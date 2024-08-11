using Entities;
using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using libraryapi.Helpers;
using libraryapi.Interfaces;

namespace libraryapi.Repositories;

public class AuthRepository :  RepositoryBase<User>, IAuthRepositiry
{
    public AuthRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
    
    public UserDto GetUserAccount(User user)
    {
        // Step 1: Retrieve the user based on the email
        var query = FindByCondition(
            usr => usr.Email.Equals(user.Email),
            usr => new UserDto
            {
                Email = usr.Email,
                FirstName = usr.FirstName,
                LastName = usr.LastName,
                Password = usr.Password,
                Role = usr.Role
            },
            usr => usr.Role);

        var foundUser = query.FirstOrDefault();

        // Step 2: If the user exists, verify the password
        if (foundUser != null && AuthHelper.Verify(user.Password, foundUser.Password))
        {
            // If the password is correct, map the user entity to a UserDto
            return query.FirstOrDefault();
        }

        // Step 3: If the user was not found or the password is incorrect, return null (or handle as needed)
        return null;
    }

}