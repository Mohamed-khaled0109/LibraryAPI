namespace LibraryAPI.DTO
{
    public class BorrowingDto
    {
        public DateTime BorrowDate { get; set; }
        public DateTime returnDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public bool State { get; set; }

        public int UserBookDorrowerId { get; set; }

    }
}
