using System.Security.Claims;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace libraryapi.Controllers;

[Route("api/[controller]")]
public class UserBookController : Controller
{
    private IRepositoryWrapper _repository;
    private readonly ClaimsPrincipal _user;
    private readonly IConfiguration _configuration;

    public UserBookController(IConfiguration configuration, IRepositoryWrapper repository)
    {
        _configuration = configuration;
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetUsersList()
    {
        IEnumerable<User> users =  _repository.User.GetAllUsers();
        return Ok(users);
    }
    [HttpPost("reserveorreturn")]
    public IActionResult ReserveOrReturnBook(Guid bookId, int status)
    {
        try
        {
            //Get loginned user info and valid 
            var userIdClaim = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var deadline = int.TryParse(_configuration["Book:Deadline"], out int Deadline) ? Deadline : 0;

                        
            //Change book status from free to reserved
            var book = _repository.Book.GetBookById(bookId);
            
            //If book is reserved can't be reserved again, same for free books
            if (status == book.Status)
                return BadRequest("This action is not allowed");
            
            book.Status = status;
            _repository.Book.UpdateBook(book);
            _repository.Save();
            
            var userBook = new UserBook
            {
                Id = Guid.NewGuid(),
                UserId =  Guid.TryParse(userIdClaim, out Guid claimedUserId) ? claimedUserId : Guid.Empty,
                BookId = bookId,
                ReservedDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddMonths(deadline),
                Status = status
            };
            _repository.UserBook.Create(userBook);
            _repository.Save();

            
            return Ok(userBook);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}