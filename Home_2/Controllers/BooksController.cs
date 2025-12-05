using Home_2.DTOs.Book;
using Home_2.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Home_2.Controllers;

[ApiController]
[Route("v1/books")]
public class BooksController : ControllerBase
{
    private readonly IBooksService _bookService;

    public BooksController(IBooksService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var books = _bookService.GetAll();
            return books.Any() ? Ok(books) : NotFound("No books found");
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
            var book = _bookService.GetById(id);
            
            if (book == null)
            {
                return NotFound($"Book with id {id} not found");
            }

            return Ok(book);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] AddBookDTO addBookDto)
    {
        try
        {
            var createdBook = _bookService.Create(addBookDto);
            
            return Ok(createdBook);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPut("{id:int}")]
    public IActionResult Put([FromRoute] int id, [FromBody] UpdateBookDTO updateBookDto)
    {
        try
        {
            if (id != updateBookDto.Id)
            {
                return BadRequest("Route id does not match book id");
            }
            
            var updatedBook = _bookService.Update(updateBookDto);
            
            if (updatedBook == null)
            {
                return NotFound($"Book with id {id} not found for update");
            }
            
            return Ok(updatedBook);
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
            var deletedBook = _bookService.Delete(id);
            
            if (deletedBook == null)
            {
                return NotFound($"Book with id {id} not found");
            }
            
            return Ok(deletedBook);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}