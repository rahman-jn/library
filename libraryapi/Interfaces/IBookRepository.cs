using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace libraryapi.Interfaces;

public interface IBookRepository : IRepositoryBase<Book>
{
    Book GetBookById(int bookId);
    void CreateBook(Book book);
}