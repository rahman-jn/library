using Entities;
using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;

namespace libraryapi.Repositories;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }

    public Book GetBookById(int bookId)
    {
        var query = FindByCondition(
            book => book.Id.Equals(bookId) && book.Active.Equals(1),
            book => new Book
            {
                Name = book.Name,
                Isbn = book.Isbn,
                Category = book.Category,
                Author = book.Author,
                PublishYear = book.PublishYear
            }
            ); 
            
        return query.FirstOrDefault();
    }
    
    public void CreateBook(Book book)
    {
        Create(book);
    }
}