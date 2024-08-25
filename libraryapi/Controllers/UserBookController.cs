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

    [HttpPost("reserve")]
    public IActionResult ReserveBook(Guid bookId)
    {
        try
        {
            var userIdClaim = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var deadline = int.TryParse(_configuration["Book:Deadline"], out int Deadline) ? Deadline : 0;

            var userBook = new UserBook
            {
                Id = Guid.NewGuid(),
                UserId =  Guid.TryParse(userIdClaim, out Guid claimedUserId) ? claimedUserId : Guid.Empty,
                BookId = bookId,
                ReservedDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddMonths(deadline),
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