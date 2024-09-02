using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libraryapi.Entities.Models;

[Table("Categories")]
public class Category
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Category name is required.")]
    public string Name { get; set; }
    

    public bool Active { get; set; } = true;
}