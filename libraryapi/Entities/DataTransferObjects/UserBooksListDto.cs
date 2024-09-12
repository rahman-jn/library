namespace Entities.DataTransferObjects;

public class UserBooksListDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid BookId { get; set; }
    public string BookName { get; set; }
    public DateTime ReserveDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    
}