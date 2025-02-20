using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class UserBookDorrower
    {
        public int Id { get; set; }
        //-------------------
        [ForeignKey("user")]
        public string UserId { get; set; }
        public User user { get; set; }

        [ForeignKey("book")]
        public int BookId { get; set; }
        public Book book { get; set; }

        public virtual ICollection<Borrowing> borrowings { get; set; }
    }
}
