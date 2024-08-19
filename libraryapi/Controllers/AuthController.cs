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
    private IConfiguration _configuration;

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
            var foundUser = _repository.User.GetUserByEmail(user.Email);
            var authResult = _repository.Auth.GetUserAccount(userEntity, foundUser);
            if (authResult != null)
            {
                var authUserEntity = _mapper.Map<User>(authResult);
                //Generate Jwt token
                var jwtToken = _authHelper.GenerateJWTToken(authUserEntity);
                //Save generated token to database
                var jwtObj = new Auth{
                    Id = Guid.NewGuid(),
                    Token = jwtToken,
                    UserId = authUserEntity.Id,
                    ExpiresAt = DateTime.Now.AddHours(1),
                    };
                _repository.Auth.CreateJwt(jwtObj);
                _repository.Save();
                authResult.Token = jwtToken;
                return Ok(authResult);
            }
            else
            {
                Console.WriteLine("Authentication failed.");
                return Unauthorized(new { message = "Invalid credentials" });
            }
            
        }
        catch (Exception e)
        {
            throw;
        }
    }
}