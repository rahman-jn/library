using AutoMapper;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace libraryapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly IRepositoryWrapper _repository;

    public CategoryController(IRepositoryWrapper repository)
    {
        _repository = repository;

    }
    
    [HttpGet("{categoryId}", Name = "CategoryById")]
    public IActionResult GetCategoryById(int categoryId)
    {
        try
        {
            var category = _repository.Category.GetCategoryById(categoryId);
            return Ok(category);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
    
    [HttpPost]
    public IActionResult CreateCategory(Category category)
    {
        try
        {
            category.Id = Guid.NewGuid();
             _repository.Category.CreateCategory(category);
            _repository.Save();
            return CreatedAtRoute("CategoryById", new {categoryId = category.Id}, category);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}