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

    public IEnumerable<Book> GetAllBooks(bool checkReserveStatus)
    {
        /*if (checkReserveStatus)
            return FindAll(
            book => book.Status == 1      
        ).ToList();*/

        return FindAll(
            checkReserveStatus ? book => book.Status==1 : null,
            book => book.Author, book => book.Category).ToList();
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
        string sql = query.ToQueryString();
        Console.WriteLine(sql);  
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