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
    private readonly IMapper _mapper;

    public BookController(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;

    }
    
    [HttpGet]
    public IActionResult GetAllBooks()
    {
        IEnumerable<Book> books = _repository.Book.GetAllBooks();
        return Ok(books);
    }
    
    [HttpGet("{id}", Name = "BookById")]
    public IActionResult GetBookById(Guid id)
    {
        try
        {
            var book = _repository.Book.GetBookById(id);
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
            return CreatedAtRoute("BookById", new {id = book.Id}, book);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

    [HttpPut("{id}")]

    public IActionResult UpdateBook(Guid id, [FromBody] Book book)
    {
        try
        {
            var bookEntity = _repository.Book.GetBookById(id);
            _mapper.Map(book, bookEntity);
            _repository.Book.UpdateBook(bookEntity);
            _repository.Save();
            return CreatedAtRoute("BookById", new { id = bookEntity.Id }, bookEntity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}