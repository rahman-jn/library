using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace libraryapi.Entities.Models;

[Table("books")]
public class Book
{
    [Key]
    public Guid  Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public string Isbn { get; set; }
    
    public int PublishYear { get; set; }
    
    [ForeignKey("Category")]
    public Guid CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    
    [Required]
    public Guid AuthorId { get; set; }
    public Author? Author { get; set; }

    public bool Active { get; set; } = true;
}