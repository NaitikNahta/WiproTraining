using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
