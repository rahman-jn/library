using Entities.DataTransferObjects;
using libraryapi.Entities.Models;

namespace libraryapi.Interfaces;

public interface IUserRepository:IRepositoryBase<User>
{
    IEnumerable<User> GetAllUsers();

    void CreateUser(User user);
    UserDto GetUserById(int userId);
    AuthUserDto GetUserByEmail(string email);
}