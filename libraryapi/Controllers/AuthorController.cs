using AutoMapper;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace libraryapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : Controller
{
    private readonly IRepositoryWrapper _repository;

    public AuthorController(IRepositoryWrapper repository)
    {
        _repository = repository;

    }
    
    [HttpGet("{authorId}", Name = "AuthorById")]
    public IActionResult GetAuthorById(int authorId)
    {
        try
        {
            var author = _repository.Author.GetAuthorById(authorId);
            return Ok(author);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
    
    [HttpPost]
    public IActionResult CreateAuthor(Author author)
    {
        try
        {
            author.Id = Guid.NewGuid();
             _repository.Author.CreateAuthor(author);
            _repository.Save();
            return CreatedAtRoute("AuthorById", new {authorId = author.Id}, author);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}