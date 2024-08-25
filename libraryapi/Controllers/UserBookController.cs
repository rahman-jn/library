using libraryapi.Entities.Models;
using libraryapi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace libraryapi.Controllers;

[Route("api/[controller]")]
public class UserBookController : Controller
{
    private IRepositoryWrapper _repository;

    //[HttpPost]
    /*public IActionResult CreateUserBook([FromBody] UserBook userBook)
    {
        try
        {
            _repository.UserBook.Create(userBook);
            var _repository.Save();
            return Ok()
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }*/
}