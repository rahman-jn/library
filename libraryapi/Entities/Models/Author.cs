using System.ComponentModel.DataAnnotations;

namespace libraryapi.Entities.Models;

public class Author
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public bool Active { get; set; } = true;

    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
}