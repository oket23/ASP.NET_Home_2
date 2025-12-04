using Home_2.Models;

namespace Home_2.Interfaces.Repositories;

public interface IBooksRepository
{
    IEnumerable<Book> GetAll();
    Book? GetById(int id);
    Book Create(Book book);
    Book? Update(Book book);
    Book? Delete(int id);
    IEnumerable<Book> GetByAuthorId(int authorId);
}