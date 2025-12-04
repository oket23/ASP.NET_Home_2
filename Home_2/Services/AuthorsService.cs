using Home_2.DTOs.Author;
using Home_2.Interfaces.Repositories;
using Home_2.Interfaces.Services;
using Home_2.Models;

namespace Home_2.Services;

public class AuthorsService : IAuthorsService
{
    private readonly IAuthorsRepository _authorsRepository;
    private readonly IBooksRepository  _booksRepository;
    private int _randomId;

    public AuthorsService(IAuthorsRepository authorsRepository, IBooksRepository booksRepository)
    {
        _authorsRepository = authorsRepository;
        _booksRepository = booksRepository;
        _randomId = 1;
    }

    public IEnumerable<Author> GetAll()
    {
        return _authorsRepository.GetAll();
    }

    public Author? GetById(int id)
    {
        return _authorsRepository.GetById(id);
    }

    public Author Create(AddAuthorDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.FirstName))
        {
            throw new ArgumentException("First name is required.");
        }
        
        if (string.IsNullOrWhiteSpace(dto.LastName))
        {
            throw new ArgumentException("Last name is required.");
        }

        var author = new Author
        {
            Id = GetNextId(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            BirthdayDate = dto.BirthdayDate
        };

        return _authorsRepository.Create(author);
    }

    public Author? Update(UpdateAuthorDTO dto)
    {
        var author = _authorsRepository.GetById(dto.Id);

        if (author is null)
        {
            return null;
        }

        var updated = new Author
        {
            Id = author.Id,
            FirstName = dto.FirstName ?? author.FirstName,
            LastName = dto.LastName ?? author.LastName,
            BirthdayDate = dto.BirthdayDate ?? author.BirthdayDate
        };

        return _authorsRepository.Update(updated);
    }

    public string? Delete(int id)
    {
        var deleted = _authorsRepository.Delete(id);

        if (deleted is null)
        {
            return null;
        }

        return $"Deleted author id:{deleted.Id}";
    }

    private int GetNextId()
    {
        return _randomId++;
    }
    
    public AuthorWithBooksDTO? GetByIdWithBooks(int id)
    {
        var author = _authorsRepository.GetById(id);
        
        if (author is null)
        {
            return null;
        }
        
        var books = _booksRepository.GetByAuthorId(id);
        
        var result = new AuthorWithBooksDTO
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            BirthdayDate = author.BirthdayDate,
            Books = books.ToList()
        };

        return result;
    }
}
