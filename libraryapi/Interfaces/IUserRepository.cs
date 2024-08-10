using Entities.DataTransferObjects;
using libraryapi.Entities.Models;

namespace libraryapi.Interfaces;

public interface IUserRepository:IRepositoryBase<User>
{
    UserDto  GetUserAccount(User user);
    IEnumerable<User> GetAllUsers();
}