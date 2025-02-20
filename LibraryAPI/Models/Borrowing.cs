using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Borrowing
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime returnDate {  get; set; }
        public DateTime ActualReturnDate { get; set; }
        public bool State { get; set; }
        //----------------
        [ForeignKey("userBookDorrower")]
        public int UserBookDorrowerId {  get; set; }
        public UserBookDorrower userBookDorrower {  get; set; }


    }
}
