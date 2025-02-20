using LibraryAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.DTO
{
    public class BookDto
    {
        public string Book_name { get; set; }
        public string Title { get; set; }
        [Required]
        public string BookPass { get; set; }
        public double price { get; set; }
        public int num_books { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public bool IsAvailable { get; set; }
        public string language { get; set; }
        public string publisher { get; set; }

        public int categoryId { get; set; }
        public int authorId { get; set; }

    }
}
