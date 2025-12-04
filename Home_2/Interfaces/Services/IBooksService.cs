using Home_2.DTOs.Book;
using Home_2.Models;

namespace Home_2.Interfaces.Services;

public interface IBooksService
{
    IEnumerable<Book> GetAll();
    Book GetById(int id);
    Book Create(AddBookDTO book);
    Book Update(UpdateBookDTO book);
    string Delete(int id);
}