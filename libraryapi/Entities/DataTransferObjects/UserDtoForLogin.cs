using libraryapi.Entities.Models;

namespace Entities.DataTransferObjects;

public class UserDtoForLogin
{
    public string Email { get; set; }
    public string Password { get; set; }
}