using Home_2.DTOs.Author;
using Home_2.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Home_2.Controllers;

[ApiController]
[Route("v1/authors")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorsService _authorsService;

    public AuthorsController(IAuthorsService authorsService)
    {
        _authorsService = authorsService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var  authors = _authorsService.GetAll();
            return  authors.Any() ? Ok( authors) : NotFound("No authors found");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        try
        {
            var author = _authorsService.GetByIdWithBooks(id);
            
            if (author == null)
            {
                return NotFound($"Author with id {id} not found");
            }

            return Ok(author);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] AddAuthorDTO addAuthorDto)
    {
        try
        {
            var createdAuthor = _authorsService.Create(addAuthorDto);
            
            return Ok(createdAuthor);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPut("{id:int}")]
    public IActionResult Put([FromRoute] int id, [FromBody] UpdateAuthorDTO authorDto)
    {
        try
        {
            if (id != authorDto.Id)
            {
                return BadRequest("Route id does not match author id");
            }
            
            var updatedAuthor = _authorsService.Update(authorDto);
            
            if (updatedAuthor == null)
            {
                return NotFound($"Author with id {id} not found for update");
            }
            
            return Ok(updatedAuthor);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute]int id)
    {
        try
        {
            var deletedAuthor = _authorsService.Delete(id);
            
            if (deletedAuthor == null)
            {
                return NotFound($"Author with id {id} not found");
            }
            
            return Ok(deletedAuthor);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}