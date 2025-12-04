namespace Home_2.DTOs.Book;

public class UpdateBookDTO
{
    public string? Name { get; set; }
    public int? PublicationYear { get; set; }
    public int? AuthorId { get; set; }
    public string? Description { get; set; }
}
