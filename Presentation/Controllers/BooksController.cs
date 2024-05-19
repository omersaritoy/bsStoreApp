using Entitiess.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contrats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers;
[ApiController]
[Route("api/book")]
public class BookController : ControllerBase
{
    private readonly IServiceManager _manager;

    public BookController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var books = _manager.BookService.GetAllBooks(false);
        return Ok(books);
    }
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult GetOneBook([FromRoute] int id)
    {
        var book = _manager.BookService.GetOneBookById(id, false);
        if (book == null)
            return NotFound();
        return Ok(book);
    }
    [HttpPost]
    public IActionResult CreateOneBook([FromBody] Book book)
    {
        if (book == null)
            return BadRequest();

        _manager.BookService.CreateOneBook(book);
        return StatusCode(201, book);
    }
    [HttpPut]
    [Route("{id:int}")]
    public IActionResult UpdateOneBook([FromRoute] int id, [FromBody] Book book)
    {
        _manager.BookService.UpdateOneBook(id, book, false);


        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var entity = _manager.BookService.GetOneBookById(id, false);
        if (entity == null)
            return NotFound();
        _manager.BookService.DeleteOneBook(id, false);
        return Ok(entity);
    }
    [HttpPatch("{id:int}")]
    public IActionResult PartiallUpdateOneBook([FromRoute] int id, [FromBody] JsonPatchDocument<Book> book)
    {
        var entity = _manager.BookService.GetOneBookById(id, false);
        if (entity == null)
            return NotFound();
        book.ApplyTo(entity);
        _manager.BookService.UpdateOneBook(id, entity, true);
        return Ok(entity);
    }

}