using LibraryAPI.DTO;
using LibraryAPI.Models;

namespace LibraryAPI.Services.Interfaces
{
    public interface IBorrowingRepo
    {
        public List<Borrowing> GetBorrowings();
        public BorrowingDto GetById(int id);
        public int creat(BorrowingDto borrowingDto);
        public BorrowingDto update(int id, BorrowingDto borrowingDto);
        public int delete(int id);
    }
}
