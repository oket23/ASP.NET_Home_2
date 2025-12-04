using Home_2.DTOs.Author;
using Home_2.Models;

namespace Home_2.Interfaces.Services;

public interface IAuthorsService
{
    
    IEnumerable<Author> GetAll();
    Author GetById(int id);
    Author Create(AddAuthorDTO book);
    Author Update(UpdateAuthorDTO book);
    string Delete(int id);
}