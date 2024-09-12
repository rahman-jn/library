using Entities;
using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;

namespace libraryapi.Repositories;

public class UserBookRepository :  RepositoryBase<UserBook>, IUserBookRepository
{
    public UserBookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }

    public void CreateUserBook(UserBook userBook)
    {
        Create(userBook);
    }

    public IEnumerable<UserBook> GetAllUsers()
    {
        return FindAll().ToList();
    }
    
    public int userReservedBooksCount(Guid userId)
    {
        var query = FindByCondition(
            usrBook => usrBook.UserId.Equals(userId) && usrBook.Active.Equals(1), 
            usrBook => new UserBook
                        {
                            Id = usrBook.Id
                        }
            );
        return query.Count();
    }

    public IEnumerable<UserBooksListDto> GetUserActivities(Guid userId)
    {
        var query = FindByCondition(
                usrBook => usrBook.UserId.Equals(userId),
                usrBook => new UserBooksListDto
                {
                    Id = usrBook.Id,
                    FirstName = usrBook.User.FirstName,
                    LastName = usrBook.User.LastName,
                    BookId = usrBook.BookId,
                    BookName = usrBook.Book.Name,
                    ReserveDate = usrBook.ReservedDate,
                    ExpirationDate = usrBook.ExpirationDate
                } 
            );
        return query.ToList();
    }
}