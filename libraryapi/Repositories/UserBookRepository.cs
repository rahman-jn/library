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
}