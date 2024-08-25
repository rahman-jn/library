using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace libraryapi.Entities.Models;

[Table("userBooks")]
public class UserBook
{
    [Key]
    public Guid  Id { get; set; }
    
    [Required]
    public Guid UserId { get; set; }
    
    [Required]
    public Guid BookId { get; set; }
    
    public DateTime ReservedDate { get; set; }
    public DateTime ExpirationDate { get; set; }

    public int Status { get; set; } = 0;
    public bool Active { get; set; } = true;
}