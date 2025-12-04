using Home_2.Interfaces.Repositories;
using Home_2.Models;

namespace Home_2.Repositories;

public class BooksRepository : IBooksRepository
{
    private readonly List<Book> _books = new();
    
    public IEnumerable<Book> GetAll()
    {
        return _books;
    }

    public Book? GetById(int id)
    {
        return _books.FirstOrDefault(a => a.Id == id);
    }

    public Book Create(Book book)
    {
        _books.Add(book);
        return book;
    }

    public Book Update(Book book)
    {
        var bookToUpdate = _books.FirstOrDefault(a => a.Id == book.Id);
        
        bookToUpdate.Name = book.Name;
        bookToUpdate.Description = book.Description;
        bookToUpdate.PublicationYear = book.PublicationYear;
        bookToUpdate.AuthorId = book.AuthorId;

        return bookToUpdate;
    }

    public Book? Delete(int id)
    {
        var bookToDelete = _books.FirstOrDefault(x => x.Id == id);

        if (bookToDelete is null)
        {
            return null;
        }

        _books.Remove(bookToDelete);
        return bookToDelete;
    }
}