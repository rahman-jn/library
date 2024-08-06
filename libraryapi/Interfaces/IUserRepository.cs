using libraryapi.Entities.Models;

namespace libraryapi.Interfaces;

public interface IUserRepository:IRepositoryBase<User>
{
    User AuthenticateUser(string userName, string password);
}