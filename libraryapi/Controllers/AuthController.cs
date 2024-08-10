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

    public AuthController(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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
            return Ok(authResult);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}