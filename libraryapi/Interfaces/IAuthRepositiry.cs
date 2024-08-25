using Entities.DataTransferObjects;
using libraryapi.Entities.Models;

namespace libraryapi.Interfaces;

public interface IAuthRepositiry : IRepositoryBase<Auth>
{
    public UserDto GetUserAccount(User user, User foundUser);
    public void CreateJwt(Auth auth);

    //public UserDto AuthenticateUser();

}