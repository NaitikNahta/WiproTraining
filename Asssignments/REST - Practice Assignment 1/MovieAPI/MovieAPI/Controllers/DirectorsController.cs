using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class DirectorsController : ControllerBase
{
    private readonly AppDbContext _context;

    public DirectorsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/directors
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Directors.ToList());
    }

    // POST: api/directors
    [HttpPost]
    public IActionResult Create(Director director)
    {
        if (string.IsNullOrEmpty(director.Name))
            return BadRequest("Director name is required");

        _context.Directors.Add(director);
        _context.SaveChanges();

        return Ok(director);
    }

    // GET: api/directors/1/movies
    [HttpGet("{directorId}/movies")]
    public IActionResult GetMoviesByDirector(int directorId)
    {
        var movies = _context.Movies
            .Where(m => m.DirectorId == directorId)
            .ToList();

        return Ok(movies);
    }
}