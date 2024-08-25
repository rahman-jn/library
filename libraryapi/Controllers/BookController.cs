using AutoMapper;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace libraryapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : Controller
{
    private readonly IRepositoryWrapper _repository;

    public BookController(IRepositoryWrapper repository)
    {
        _repository = repository;

    }
    
    [HttpGet("{bookId}", Name = "BookById")]
    public IActionResult GetBookById(int bookId)
    {
        try
        {
            var book = _repository.Book.GetBookById(bookId);
            return Ok(book);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
    
    [HttpPost]
    public IActionResult CreateBook(Book book)
    {
        try
        {
            book.Id = Guid.NewGuid();
            _repository.Book.CreateBook(book);
            _repository.Save();
            return CreatedAtRoute("BookById", new {bookId = book.Id}, book);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }


}