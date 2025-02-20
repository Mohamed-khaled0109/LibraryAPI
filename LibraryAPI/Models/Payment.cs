using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public bool State {  get; set; }
        public double amount {  get; set; }
        public DateTime PaymentDate {  get; set; }
        //----------------------------
        [ForeignKey("book")]
        public int BookId {  get; set; }
        public Book book { get; set; }

        [ForeignKey("user")]
        public string UserId { get; set; }
        public User user { get; set; }
    }
}
