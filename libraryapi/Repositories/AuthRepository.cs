using System.Linq.Expressions;
using System.Security.Claims;
using Entities;
using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using libraryapi.Helpers;
using libraryapi.Interfaces;

namespace libraryapi.Repositories;

public class AuthRepository :  RepositoryBase<Auth>, IAuthRepositiry
{
    private readonly ClaimsPrincipal _user;

    public AuthRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        /*_user = httpContextAccessor.HttpContext?.User;*/
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

    //Get Jwt token, validate it and ectract authenticated user info from token.
    /*public UserDto AuthenticateUser()
    {
        var roleIdClaim = _user?.FindFirst("RoleId")?.Value;
        var userIdClaim = _user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        var fullName = _user?.FindFirst(ClaimTypes.Name)?.Value;
        var email = _user?.FindFirst("Email")?.Value;
        var roleId = int.TryParse(roleIdClaim, out int claimedRoleId) ? claimedRoleId : 0;
        var userId = Guid.TryParse(userIdClaim, out Guid claimedUserId) ? claimedUserId : Guid.Empty;

        return new UserDto
        {
            Id = userId,
            FullName = fullName,
            Email = email,
            RoleId = roleId,
        };
    }*/
}