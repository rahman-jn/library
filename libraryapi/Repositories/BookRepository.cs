using Entities;
using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace libraryapi.Repositories;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return FindAll().ToList();
    }
    public Book GetBookById(Guid id)
    {
        var query = FindByCondition(
            book => book.Id.Equals(id),
            book => new Book
            {
                Id = book.Id,
                Name = book.Name,
                Isbn = book.Isbn,
                CategoryId = book.CategoryId,
                AuthorId = book.AuthorId,
                PublishYear = book.PublishYear,
                Status = book.Status,
                Active = book.Active
            }
            ); 
            
        return query.FirstOrDefault();
    }
    
    public void CreateBook(Book book)
    {
        Create(book);
    }

    public void UpdateBook(Book book)
    {
        Update(book);
    }
}