using LibraryAPI.Models;

namespace LibraryAPI.DTO

{
    public class ReviewDto
    {
        public string Comment { get; set; }
        public Rate rate { get; set; }

        public int BookId { get; set; }
        public string UserId { get; set; }
    }
}
