using Entities.DataTransferObjects;
using libraryapi.Entities.Models;

namespace libraryapi.Interfaces;

public interface IUserBookRepository : IRepositoryBase<UserBook>
{
    void CreateUserBook(UserBook userBook);
    IEnumerable<UserBooksListDto> GetUserActivities(Guid userId);
}