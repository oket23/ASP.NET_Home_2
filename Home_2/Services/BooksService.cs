using Home_2.DTOs.Book;
using Home_2.Interfaces.Repositories;
using Home_2.Interfaces.Services;
using Home_2.Models;

namespace Home_2.Services;

public class BooksService : IBooksService
{
    private readonly IBooksRepository _booksRepository;
    private readonly IValidationService _validationService;
    private int _randomId;

    public BooksService(
        IBooksRepository repository, 
        IValidationService validationService)
    {
        _randomId = 1;
        _booksRepository = repository;
        _validationService = validationService;
    }
    
    public IEnumerable<Book> GetAll()
    {
        return _booksRepository.GetAll();
    }

    public Book? GetById(int id)
    {
        return _booksRepository.GetById(id);
    }

    public Book Create(AddBookDTO addBookDto)
    {
        if (!_validationService.IsValidAuthor(addBookDto.AuthorId))
        {
            throw new ArgumentException("Author with given id does not exist.");
        }
       
        if (!_validationService.IsValidDescription(addBookDto.Description))
        {
            throw new ArgumentException("Description contains censored words or is invalid.");
        }

        var book = new Book
        {
            Id = GetRandomId(),
            Name = addBookDto.Name,
            PublicationYear = addBookDto.PublicationYear,
            AuthorId = addBookDto.AuthorId,
            Description = addBookDto.Description
        };
        
        return _booksRepository.Create(book);
    }

    public Book? Update(UpdateBookDTO updateBookDto)
    {
        var book = _booksRepository.GetById(updateBookDto.Id);
        
        if (book == null)
        {
            return null;
        }
        
        var newAuthorId = updateBookDto.AuthorId ?? book.AuthorId;
        var newDescription = updateBookDto.Description ?? book.Description;
        
        if (!_validationService.IsValidAuthor(newAuthorId))
        {
            throw new ArgumentException("Author with given id does not exist.");
        }
        
        if (!_validationService.IsValidDescription(newDescription))
        {
            throw new ArgumentException("Description contains censored words or is invalid.");
        }

        var updatedBook = new Book
        {
            Id = book.Id,
            Name = updateBookDto.Name ?? book.Name,
            PublicationYear = updateBookDto.PublicationYear ?? book.PublicationYear,
            AuthorId = newAuthorId,
            Description = newDescription
        };

        return _booksRepository.Update(updatedBook);
    }

    public string? Delete(int id)
    {
        var book = _booksRepository.Delete(id);
        if (book == null)
        {
            return null;
        }

        return $"Deleted book id:{book.Id}";
    }

    private int GetRandomId()
    {
        return _randomId++;
    }
}
