using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly AppDbContext _context;

    public MoviesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/movies
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Movies.ToList());
    }

    // GET: api/movies/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
            return NotFound("Movie not found");

        return Ok(movie);
    }

    // POST: api/movies
    [HttpPost]
    public IActionResult Create(Movie movie)
    {
        if (string.IsNullOrEmpty(movie.Title))
            return BadRequest("Title is required");

        _context.Movies.Add(movie);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
    }

    // PUT: api/movies/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, Movie updatedMovie)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
            return NotFound("Movie not found");

        movie.Title = updatedMovie.Title;
        movie.ReleaseYear = updatedMovie.ReleaseYear;
        movie.DirectorId = updatedMovie.DirectorId;

        _context.SaveChanges();

        return Ok(movie);
    }

    // DELETE: api/movies/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
            return NotFound("Movie not found");

        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return Ok("Deleted successfully");
    }
}