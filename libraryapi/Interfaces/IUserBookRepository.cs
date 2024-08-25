using libraryapi.Entities.Models;

namespace libraryapi.Interfaces;

public interface IUserBookRepository : IRepositoryBase<UserBook>
{
    void CreateUserBook(UserBook userBook);
}