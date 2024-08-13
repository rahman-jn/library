using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace libraryapi.Entities.Models;

[Table("AuthTokens")]
[Index(nameof(Token), IsUnique = true)]
public class Auth
{
    [Key]
    public Guid  Id { get; set; }
    [Required]
    public string Token { get; set; }
    [Required]
    public DateTime ExpiresAt { get; set; }
    public DateTime RevokedAt { get; set; }
    public bool IsRevoked { get; set; }
    public Guid  UserId { get; set; }
    
    //public User User { get; set; }
}