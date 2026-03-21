using System.Text.Json.Serialization;

namespace MovieAPI.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Movie>? Movies { get; set; }
    }
}
