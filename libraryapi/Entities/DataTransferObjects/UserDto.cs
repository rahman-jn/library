using System.ComponentModel.DataAnnotations;
using libraryapi.Entities.Models;

namespace Entities.DataTransferObjects;

public class UserDto
{
    public Guid  Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    
    public int RoleId { get; set; }
}