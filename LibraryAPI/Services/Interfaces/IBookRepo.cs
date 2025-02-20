using LibraryAPI.DTO;
using LibraryAPI.Models;

namespace LibraryAPI.Services.Interfaces
{
    public interface IBookRepo
    {
        public List<Book> GetBooks();
        public BookDto GetById(int id);
        public BookDto GetByName(string name);
        public int creat(BookDto bookDto);
        public BookDto update(int id, BookDto bookDto);
        public int Delete(int id);
    }
}
