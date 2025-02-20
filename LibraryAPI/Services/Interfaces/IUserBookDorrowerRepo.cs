using LibraryAPI.DTO;
using LibraryAPI.Models;

namespace LibraryAPI.Services.Interfaces
{
    public interface IUserBookDorrowerRepo
    {
        public List<UserBookDorrower> GetAll();
        public UserBookDorrowerDto GetById(int id);
        public int create(UserBookDorrowerDto userBookDorrowerDto);
        public UserBookDorrowerDto update(int id, UserBookDorrowerDto userBookDorrowerDto);
        public int delete(int id);
    }
}
