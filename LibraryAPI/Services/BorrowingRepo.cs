using LibraryAPI.DTO;
using LibraryAPI.Models;
using LibraryAPI.Services.Interfaces;

namespace LibraryAPI.Services
{
    public class BorrowingRepo: IBorrowingRepo
    {
        private readonly Context context;

        public BorrowingRepo(Context context)
        {
            this.context = context;
        }

        public List<Borrowing> GetBorrowings()
        {
            return context.borrowings.ToList();
        }
        public BorrowingDto GetById(int id)
        {
            var borrowing=context.borrowings.FirstOrDefault(B => B.Id == id);
            var borrowingDto = new BorrowingDto();
            
            borrowingDto.BorrowDate=borrowing.BorrowDate;
            borrowingDto.returnDate = borrowing.returnDate;
            borrowingDto.UserBookDorrowerId=borrowing.UserBookDorrowerId;
            borrowingDto.ActualReturnDate=borrowing.ActualReturnDate;
            borrowingDto.State=borrowing.State;
            
            return borrowingDto;
        }

        public int creat(BorrowingDto borrowingDto)
        {
            var borrowing = new Borrowing();

            borrowing.BorrowDate = borrowingDto.BorrowDate;
            borrowing.returnDate = borrowingDto.returnDate;
            borrowing.UserBookDorrowerId = borrowingDto.UserBookDorrowerId;
            borrowing.ActualReturnDate = borrowingDto.ActualReturnDate;
            borrowing.State = borrowingDto.State;
            
            context.borrowings.Add(borrowing);
            return context.SaveChanges();
            
        }

        public BorrowingDto update(int id, BorrowingDto borrowingDto)
        {
            var borrowing = context.borrowings.FirstOrDefault(A=>A.Id==id);

            borrowing.BorrowDate = borrowingDto.BorrowDate;
            borrowing.returnDate = borrowingDto.returnDate;
            borrowing.UserBookDorrowerId = borrowingDto.UserBookDorrowerId;
            borrowing.ActualReturnDate = borrowingDto.ActualReturnDate;
            borrowing.State = borrowingDto.State;

            context.SaveChanges();
            return borrowingDto;
        }

        public int delete(int id)
        {
            var borrowing = context.borrowings.FirstOrDefault(A => A.Id == id);
            context.borrowings.Remove(borrowing);
            return context.SaveChanges();
        }
    }
}
