using Entities.DataTransferObjects;
using libraryapi.Entities.Models;

namespace libraryapi.Interfaces;

public interface IAuthRepositiry : IRepositoryBase<Auth>
{
    public UserDto GetUserAccount(User user, AuthUserDto foundUser);
    public void CreateJwt(Auth auth);

}