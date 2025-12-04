namespace Home_2.DTOs.Author;

using Home_2.Models;

public class AuthorWithBooksDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthdayDate { get; set; }
    public List<Book> Books { get; set; }
}