using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects;

public class UserListDto
{
    public Guid UserId;
    public string FirstName{ get; set; }
    public string LastName { get; set; }
    
    [EmailAddress]
    public string Email{ get; set; }

    public DateTime CreatedAt { get; set; }
    
    public int ReservedBooksCount{ get; set; }
}