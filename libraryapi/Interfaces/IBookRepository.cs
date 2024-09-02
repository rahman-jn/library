using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace libraryapi.Interfaces;

public interface IBookRepository : IRepositoryBase<Book>
{
    Book GetBookById(Guid bookId);
    IEnumerable<Book> GetAllBooks(bool checkReservStatus);
    void CreateBook(Book book);
    void UpdateBook(Book book);
}