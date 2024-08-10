using AutoMapper;
using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace libraryapi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : Controller
{
    private readonly IRepositoryWrapper _repository;
    private IMapper _mapper;
    
    public UserController(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("{userId}", Name = "UserById")]
    public IActionResult GetUserById(int userId)
    {
        try
        {
            var user = _repository.User.GetUserById(userId);
            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
    
    [HttpPost]
    public IActionResult CreateUser([FromBody] UserDtoForCreation user)
    {
        try
        {
            var userEntity = _mapper.Map<User>(user);
            _repository.User.CreateUser(userEntity);
            _repository.Save();
            var createdUser = _mapper.Map<UserDto>(userEntity);
            return CreatedAtRoute("UserById", new {Id = createdUser.Id}, createdUser);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
    
}