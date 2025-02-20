using LibraryAPI.DTO;
using LibraryAPI.Models;
using LibraryAPI.Services.Interfaces;

namespace LibraryAPI.Services
{
    public class AuthorRepo:IAuthorRepo
    {
        private readonly Context context;

        public AuthorRepo(Context _context) 
        {
            context = _context;
        }

        public List<Author> GetAuthors()
        {
            return context.authors.ToList();
        }

        public AuthorDto GetById(int id)
        {
            var auther=context.authors.FirstOrDefault(a=>a.Id==id);
            
            var autherDto=new AuthorDto();
            autherDto.Name = auther.Name;
            foreach(var item in auther.Books)
            {
                autherDto.Books.Add(item.Name.ToString());
            }
            return autherDto;
        }
        public AuthorDto GetByName(string name)
        {
            var auther = context.authors.FirstOrDefault(a => a.Name == name);

            var autherDto = new AuthorDto();
            autherDto.Name = auther.Name;
            foreach (var item in auther.Books)
            {
                autherDto.Books.Add(item.Name.ToString());
            }
            return autherDto;
        }

        public int creat(AuthorDto authorDto)
        {
            var auther=new Author();
            auther.Name = authorDto.Name;
            context.authors.Add(auther);
            return context.SaveChanges();
        }

        public AuthorDto Update(int id, AuthorDto authorDto)
        {
            var auther=context.authors.FirstOrDefault(A=>A.Id==id);
            auther.Name = authorDto.Name;

            context.SaveChanges();
            return authorDto;
        }

        public int delete (int id)
        {
            var auther = context.authors.FirstOrDefault(A => A.Id==id);
            context.authors.Remove(auther);
            return context.SaveChanges();
        }
    }
}
