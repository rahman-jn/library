using AutoMapper;
using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using libraryapi.Helpers;
using libraryapi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace libraryapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private  readonly IRepositoryWrapper _repository;
    private IMapper _mapper;
    private AuthHelper _authHelper;

    public AuthController(IRepositoryWrapper repository, IMapper mapper, AuthHelper authHelper)
    {
        _repository = repository;
        _mapper = mapper;
        _authHelper = authHelper;
    }
    
    //Login method
    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromBody] UserDtoForLogin user)
    {
        if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            return BadRequest("Invalid request");
        try
        {
            var userEntity = _mapper.Map<User>(user);
            var authResult = _repository.Auth.GetUserAccount(userEntity);
            if (authResult != null)
            {
                var authUserEntity = _mapper.Map<User>(authResult);
                var jwtToken = _authHelper.GenerateJWTToken(authUserEntity);
                Console.WriteLine(jwtToken);
                return Ok(authResult);
            }
            else
            {
                // If authentication fails, log the event and return an unauthorized response
                Console.WriteLine("Authentication failed.");

                // Example return (assuming this is in a controller action)
                return Unauthorized(new { message = "Invalid credentials" });
            }
            
        }
        catch (Exception e)
        {
            throw;
        }
    }
}