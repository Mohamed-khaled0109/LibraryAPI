using LibraryAPI.DTO;
using LibraryAPI.Models;
using LibraryAPI.Services.Interfaces;

namespace LibraryAPI.Services
{
    public class ReviewRepo:IReviewRepo
    {
        private readonly Context context;

        public ReviewRepo(Context context)
        {
            this.context = context;
        }

        public List<Review> GetAll()
        {
            return context.reviews.ToList();
        }

        public ReviewDto GetbyId(int id)
        {
            var review =context.reviews.FirstOrDefault(r=> r.Id == id);
            var reviewDto=new ReviewDto();
            
            reviewDto.rate = review.rate;
            reviewDto.UserId= review.UserId;
            reviewDto.BookId = review.BookId;
            reviewDto.Comment = review.Comment;

            return reviewDto;
        }

        public int creat(ReviewDto reviewDto)
        {
            var review = new Review();

            review.rate = reviewDto.rate;
            review.UserId = reviewDto.UserId;
            review.BookId = reviewDto.BookId;
            review.Comment = reviewDto.Comment;

            context.reviews.Add(review);
            return context.SaveChanges();
        }

        public ReviewDto update(int id,ReviewDto reviewDto)
        {
            var review = context.reviews.FirstOrDefault(r => r.Id == id);

            review.rate = reviewDto.rate;
            review.UserId = reviewDto.UserId;
            review.BookId = reviewDto.BookId;
            review.Comment = reviewDto.Comment;

            context.SaveChanges();
            return reviewDto;
        }

        public int delete(int id)
        {
            var review = context.reviews.FirstOrDefault(r => r.Id == id);
            context.reviews.Remove(review);
            return context.SaveChanges();
        }

    }
}
