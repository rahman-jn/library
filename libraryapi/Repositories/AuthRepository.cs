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
        var query = FindByCondition(
            usr => usr.Email.Equals(user.Email),
            usr => new UserDto
            {
                Id = usr.Id,
                Email = usr.Email,
                FirstName = usr.FirstName,
                LastName = usr.LastName,
                Password = usr.Password,
                Role = usr.Role
            },
            usr => usr.Role);

        var foundUser = query.FirstOrDefault();

        if (foundUser != null && AuthHelper.Verify(user.Password, foundUser.Password))
        {
            // If the password is correct, map the user entity to a UserDto
            return foundUser;
        }
        return null;
    }

}