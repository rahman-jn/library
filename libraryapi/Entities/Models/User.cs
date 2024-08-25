using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace libraryapi.Entities.Models;

[Table("users")]
[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    public Guid  Id { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Column("PasswordHash", TypeName = "varchar(256)")]
    public string Password { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }
    
    public ICollection<UserBook> UserBooks { get; set; }
}