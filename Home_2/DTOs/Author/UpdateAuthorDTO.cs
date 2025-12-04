namespace Home_2.DTOs.Author;

public class UpdateAuthorDTO
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthdayDate { get; set; }
}