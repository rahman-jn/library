using Entities;
using Entities.DataTransferObjects;
using libraryapi.Entities.Models;
using libraryapi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;



namespace libraryapi.Repositories;

public class UserRepository : RepositoryBase<User> , IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }

    public UserDto GetUserById(int userId)
    {
        var query = FindByCondition(
            usr => usr.Id.Equals(userId),
            usr => new UserDto
            {
                Email = usr.Email,
                FirstName = usr.FirstName,
                LastName = usr.LastName,
            },
            usr => usr.Role); 
        
        //View the SQL query
        string sql = query.ToQueryString();
        Console.WriteLine(sql);  
            
            return query.FirstOrDefault();
    }
    
    public User GetUserByEmail(string email)
    {
        var query = FindByCondition(
            usr => usr.Email.Equals(email),
            usr => new User
            {
                Id = usr.Id,
                Email = usr.Email,
                FirstName = usr.FirstName,
                LastName = usr.LastName,
                Password = usr.Password,
                RoleId = usr.RoleId
            },
            usr => usr.Role); 
            
        return query.FirstOrDefault();
    }
    public IEnumerable<User> GetAllUsers()
    {
        return FindAll(null, usr => usr.UserBooks).ToList();
    }

    public void CreateUser(User user)
    {
        Create(user);
    }
    
}