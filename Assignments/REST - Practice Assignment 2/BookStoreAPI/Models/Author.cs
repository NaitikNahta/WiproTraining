using BookStoreAPI.Models;
using System.Text.Json.Serialization;
namespace BookStoreAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [JsonIgnore]
        public List<Book>? Books { get; set; }

    }
}
