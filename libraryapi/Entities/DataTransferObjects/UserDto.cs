using System.ComponentModel.DataAnnotations;
using libraryapi.Entities.Models;

namespace Entities.DataTransferObjects;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string lastName { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
}