using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
   public enum Rate
    {
        bad=0,
        good=1,
        verygood=2,
        excellent=3
    }
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public Rate rate { get; set; }
        //-------------------------
        [ForeignKey("user")]
        public string UserId {  get; set; }
        public User user { get; set; }

        [ForeignKey("book")]
        public int BookId { get; set; }
        public Book book { get; set; }
    }
}
