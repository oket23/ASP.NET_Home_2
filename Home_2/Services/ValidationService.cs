using System.Text.RegularExpressions;
using Home_2.Interfaces.Repositories;
using Home_2.Interfaces.Services;

namespace Home_2.Services;

public class ValidationService : IValidationService
{
    private readonly IAuthorsRepository _authorsRepository;
    private static readonly string[] _censoredWords = {"the", "no"};
    public ValidationService(IAuthorsRepository authorsRepository)
    {
        _authorsRepository = authorsRepository;
    }

    public bool IsValidDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            return false;
        }
        
        var lowered = description.ToLowerInvariant();
        var words = Regex.Split(lowered, @"\W+", RegexOptions.Compiled);

        return !_censoredWords.Any(censored => words.Contains(censored));
    }

    public bool IsValidAuthor(int authorId)
    {
        return _authorsRepository.GetById(authorId) != null;
    }
}