using LibraryAPI.DTO;
using LibraryAPI.Models;
using LibraryAPI.Services.Interfaces;
using System.Xml.Linq;

namespace LibraryAPI.Services
{
    public class BookRepo: IBookRepo
    {
        private readonly Context context;

        public BookRepo(Context _context)
        {
            context = _context;
        }

        public List<Book> GetBooks()
        {
            var books = context.books.ToList();
            
            return books;
        }
        public BookDto GetById(int id)
        {
            var book=context.books.FirstOrDefault(b=>b.Id==id);
            var bookDto=new BookDto();
            
            bookDto.price = book.prise;
            bookDto.BookPass=book.BookPass;
            bookDto.publisher= book.publisher;
            bookDto.description=book.Description;
            bookDto.image = book.imagUrl;
            bookDto.Book_name = book.Name;
            bookDto.authorId = book.authorId;
            bookDto.categoryId = book.categoryId;
            bookDto.Title = book.Title;
            bookDto.IsAvailable= book.IsAvailable;
            bookDto.language= book.language;

            return bookDto;
        }

        public BookDto GetByName(string name)
        {
            var book = context.books.FirstOrDefault(b => b.Name == name);
            var bookDto = new BookDto();

            bookDto.price = book.prise;
            bookDto.publisher = book.publisher;
            bookDto.BookPass = book.BookPass;
            bookDto.description = book.Description;
            bookDto.image = book.imagUrl;
            bookDto.Book_name = book.Name;
            bookDto.authorId = book.authorId;
            bookDto.categoryId = book.categoryId;
            bookDto.Title = book.Title;
            bookDto.IsAvailable = book.IsAvailable;
            bookDto.language = book.language;

            return bookDto;
        }

        public int creat(BookDto bookDto)
        {
            var book = new Book();

            book.prise = bookDto.price;
            book.publisher = bookDto.publisher;
            book.BookPass = bookDto.BookPass;
            book.Description = bookDto.description;
            book.imagUrl = bookDto.image;
            book.Name = bookDto.Book_name;
            book.authorId = bookDto.authorId;
            book.categoryId = bookDto.categoryId;
            book.Title = bookDto.Title;
            book.IsAvailable = bookDto.IsAvailable;
            book.language = bookDto.language;

            context.books.Add(book);
            var numOfrows=context.SaveChanges();

            return numOfrows;

        }

        public BookDto update(int id,BookDto bookDto)
        {
            var book = context.books.FirstOrDefault(b=>b.Id==id);

            book.prise = bookDto.price;
            book.publisher = bookDto.publisher;
            book.BookPass = bookDto.BookPass;
            book.Description = bookDto.description;
            book.imagUrl = bookDto.image;
            book.Name = bookDto.Book_name;
            book.authorId = bookDto.authorId;
            book.categoryId = bookDto.categoryId;
            book.Title = bookDto.Title;
            book.IsAvailable = bookDto.IsAvailable;
            book.language = bookDto.language;

            context.books.Add(book);
            context.SaveChanges();
            return bookDto;
        }

        public int Delete(int id)
        {
            var book = context.books.FirstOrDefault(b => b.Id == id);
            context.books.Remove(book);
            var numOfRows=context.SaveChanges();
            return numOfRows;
        }


    }
}
