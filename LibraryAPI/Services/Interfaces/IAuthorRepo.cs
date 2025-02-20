using LibraryAPI.DTO;
using LibraryAPI.Models;

namespace LibraryAPI.Services.Interfaces
{
    public interface IAuthorRepo
    {
        public List<Author> GetAuthors();
        public AuthorDto GetById(int id);
        public AuthorDto GetByName(string name);
        public int creat(AuthorDto authorDto);
        public AuthorDto Update(int id, AuthorDto authorDto);
        public int delete(int id);

    }
}
