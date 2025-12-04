namespace Home_2.DTOs.Author;

public class AddAuthorDTO
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime BirthdayDate { get; set; }
}