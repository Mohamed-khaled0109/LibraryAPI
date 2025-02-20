using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDate {  get; set; }
        //-------------------------
        [ForeignKey("book")]
        public int BookId { get; set; }
        public Book book { get; set; }

        [ForeignKey("user")]
        public string UserId { get; set; }
        public User user { get; set; }
    }
}
