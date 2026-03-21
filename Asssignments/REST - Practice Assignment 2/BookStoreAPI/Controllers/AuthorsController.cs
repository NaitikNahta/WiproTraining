using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

[ApiController]
[Route("api/authors")]
public class AuthorsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthorsController(AppDbContext context)
    {
        _context = context;
    }

    // ✅ GET all authors
    [HttpGet]
    public IActionResult GetAllAuthors()
    {
        return Ok(_context.Authors.ToList());
    }

    // ✅ GET author by ID
    [HttpGet("{id}")]
    public IActionResult GetAuthorById(int id)
    {
        var author = _context.Authors.Find(id);
        if (author == null)
            return NotFound("Author not found");

        return Ok(author);
    }

    // ✅ POST create author ⭐ IMPORTANT
    [HttpPost]
    public IActionResult CreateAuthor(Author author)
    {
        if (string.IsNullOrEmpty(author.Name))
            return BadRequest("Author name is required");

        _context.Authors.Add(author);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
    }

    // ✅ PUT update author
    [HttpPut("{id}")]
    public IActionResult UpdateAuthor(int id, Author updatedAuthor)
    {
        var author = _context.Authors.Find(id);
        if (author == null)
            return NotFound("Author not found");

        author.Name = updatedAuthor.Name;

        _context.SaveChanges();

        return Ok(author);
    }

    // ✅ DELETE author
    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        var author = _context.Authors.Find(id);
        if (author == null)
            return NotFound("Author not found");

        _context.Authors.Remove(author);
        _context.SaveChanges();

        return Ok("Author deleted successfully");
    }

    // ✅ GET books by author (you already had this)
    [HttpGet("{authorId}/books")]
    public IActionResult GetBooksByAuthor(int authorId)
    {
        var books = _context.Books
            .Where(b => b.AuthorId == authorId)
            .ToList();

        if (!books.Any())
            return NotFound("No books found for this author");

        return Ok(books);
    }
}