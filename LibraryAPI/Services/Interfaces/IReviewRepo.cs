using LibraryAPI.DTO;
using LibraryAPI.Models;

namespace LibraryAPI.Services.Interfaces
{
    public interface IReviewRepo
    {
        public List<Review> GetAll();
        public ReviewDto GetbyId(int id);
        public int creat(ReviewDto reviewDto);
        public ReviewDto update(int id, ReviewDto reviewDto);
        public int delete(int id);

    }
}
