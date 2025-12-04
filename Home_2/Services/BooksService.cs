using Home_2.DTOs.Book;
using Home_2.Interfaces.Repositories;
using Home_2.Interfaces.Services;
using Home_2.Models;

namespace Home_2.Services;

public class BooksService : IBooksService
{
    private readonly IBooksRepository _booksRepository;
    private readonly IValidationService _validationService;
    public BooksService(IBooksRepository repository, IValidationService validationService)
    {
        _booksRepository = repository;
        _validationService = validationService;
    }
    
    public IEnumerable<Book> GetAll()
    {
        return _booksRepository.GetAll();
    }

    public Book GetById(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id can't be zero or negative");
        }
        var book = _booksRepository.GetById(id);

        if (book == null)
        {
            throw new ArgumentException("Book not found");
        }
        
        return book;
    }

    public Book Create(AddBookDTO book)
    {
        throw new NotImplementedException();
    }

    public Book Update(UpdateBookDTO updateBookDto)
    {
        var book = _booksRepository.GetById(updateBookDto.Id);
        
        if (book == null)
        {
            throw new NullReferenceException("Book to update not found");
        }

        return _booksRepository.Update(new Book
        {
            Id = updateBookDto.Id,
            Name = updateBookDto.Name ?? book.Name,
            PublicationYear = updateBookDto.PublicationYear ?? book.PublicationYear,
            AuthorId = updateBookDto.AuthorId ?? book.AuthorId, // перевіряти чи автор існує
            Description = updateBookDto.Description ?? book.Description // валідувати опис
        });
    }

    public string Delete(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id can't be zero or negative");
        }

        var book = _booksRepository.Delete(id);
        if (book == null)
        {
            throw new ArgumentException("Book not found");
        }

        return $"Deleted book id:{book.Id}";
    }
}