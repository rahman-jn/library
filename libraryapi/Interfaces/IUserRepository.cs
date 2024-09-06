using Entities.DataTransferObjects;
using libraryapi.Entities.Models;

namespace libraryapi.Interfaces;

public interface IUserRepository:IRepositoryBase<User>
{
    IEnumerable<User> GetAllUsers();

    void CreateUser(User user);
    void UpdateUser(User user);
    User GetUserById(Guid userId);
    User GetUserByEmail(string email);
}