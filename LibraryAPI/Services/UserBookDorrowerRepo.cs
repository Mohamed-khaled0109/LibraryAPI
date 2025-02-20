using LibraryAPI.DTO;
using LibraryAPI.Models;
using LibraryAPI.Services.Interfaces;

namespace LibraryAPI.Services
{
    public class UserBookDorrowerRepo: IUserBookDorrowerRepo
    {
        private readonly Context context;

        public UserBookDorrowerRepo(Context context)
        {
            this.context = context;
        }

        public List<UserBookDorrower> GetAll()
        {
            return context.userBookDorrowers.ToList();
        }

        public UserBookDorrowerDto GetById(int id)
        {
            var userBookDorrower=context.userBookDorrowers.FirstOrDefault(S=>S.Id==id);
            var userBookDorrowerDto=new UserBookDorrowerDto();

            userBookDorrowerDto.UserId = userBookDorrower.UserId;
            userBookDorrowerDto.BookId = userBookDorrower.BookId;
            foreach (var item in userBookDorrower.borrowings)
            {
                userBookDorrowerDto.borrowingsIdes.Add(item.Id.ToString());
            }
            return userBookDorrowerDto;
        }

        public int create(UserBookDorrowerDto userBookDorrowerDto)
        {
            var userBookDorrower = new UserBookDorrower();
            
            userBookDorrower.UserId = userBookDorrowerDto.UserId;
            userBookDorrower.BookId = userBookDorrowerDto.BookId;
            
            context.userBookDorrowers.Add(userBookDorrower);
            return context.SaveChanges();
        }

        public UserBookDorrowerDto update(int id,UserBookDorrowerDto userBookDorrowerDto)
        {
            var userBookDorrower = context.userBookDorrowers.FirstOrDefault(S => S.Id == id);

            userBookDorrower.UserId = userBookDorrowerDto.UserId;
            userBookDorrower.BookId = userBookDorrowerDto.BookId;

            context.SaveChanges();
            return userBookDorrowerDto;
        }

        public int delete(int id)
        {
            var userBookDorrower = context.userBookDorrowers.FirstOrDefault(S => S.Id == id);
            context.userBookDorrowers.Remove(userBookDorrower);
            return context.SaveChanges();
        }


    }
}
