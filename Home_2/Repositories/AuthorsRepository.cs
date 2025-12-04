using Home_2.Interfaces.Repositories;
using Home_2.Models;

namespace Home_2.Repositories;

public class AuthorsRepository : IAuthorsRepository
{
    private readonly List<Author> _authors = new();

    public IEnumerable<Author> GetAll()
    {
        return _authors;
    }

    public Author? GetById(int id)
    {
        return _authors.FirstOrDefault(a => a.Id == id);
    }

    public Author Create(Author author)
    {
        _authors.Add(author);
        return author;
    }

    public Author? Update(Author author)
    {
        var authorToUpdate = _authors.FirstOrDefault(a => a.Id == author.Id);

        if (authorToUpdate is null)
        {
            return null;
        }

        authorToUpdate.FirstName = author.FirstName;
        authorToUpdate.LastName = author.LastName;
        authorToUpdate.BirthdayDate = author.BirthdayDate;

        return authorToUpdate;
    }

    public Author? Delete(int id)
    {
        var authorToDelete = _authors.FirstOrDefault(x => x.Id == id);

        if (authorToDelete is null)
        {
            return null;
        }

        _authors.Remove(authorToDelete);
        return authorToDelete;
    }
}