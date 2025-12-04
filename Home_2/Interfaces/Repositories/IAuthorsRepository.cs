using Home_2.Models;

namespace Home_2.Interfaces.Repositories;

public interface IAuthorsRepository
{
    IEnumerable<Author> GetAll();
    Author? GetById(int id);
    Author Create(Author author);
    Author? Update(Author author);
    Author? Delete(int id);
}