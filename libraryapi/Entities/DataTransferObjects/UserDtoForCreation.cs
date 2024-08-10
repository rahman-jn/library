using libraryapi.Entities.Models;
namespace Entities.DataTransferObjects;

public class UserDtoForCreation
{
    
    public string FirstName { get; set; }
    
    
    public string LastName { get; set; }
    
    
    public string Email { get; set; }
    
    
    public string Password { get; set; }
}