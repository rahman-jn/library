using System.Linq.Expressions;
using Entities;
using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using libraryapi.Helpers;
using libraryapi.Interfaces;

namespace libraryapi.Repositories;

public class AuthRepository :  RepositoryBase<Auth>, IAuthRepositiry
{
    public AuthRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }
    
    public UserDto GetUserAccount(User user, User foundUser)
    {

        if (foundUser != null && AuthHelper.Verify(user.Password, foundUser.Password))
        {
            // If the password is correct, map the user entity to a UserDto
            return new UserDto
            {
                Id = foundUser.Id,
                Email = foundUser.Email,
                FirstName = foundUser.FirstName,
                LastName = foundUser.LastName,
                RoleId = foundUser.RoleId
            };
        }
        return null;
    }

    public void CreateJwt(Auth auth)
    {
        Create(auth);
    }


    public IQueryable<Auth> FindAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<TResult> FindByCondition<TResult>(Expression<Func<Auth, bool>> expression, Expression<Func<Auth, TResult>> selector, params Expression<Func<Auth, object>>[] includes)
    {
        throw new NotImplementedException();
    }

}