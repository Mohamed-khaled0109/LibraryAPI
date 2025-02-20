using LibraryAPI.DTO;
using LibraryAPI.Models;

namespace LibraryAPI.Services.Interfaces
{
    public interface ICategoryRepo
    {
        public List<Category> GetAll();
        public CategoryDto GetById(int id);
        public CategoryDto GetByName(string name);
        public int create(CategoryDto categoryDto);
        public CategoryDto update(int id, CategoryDto categoryDto);
        public int delete(int id);
    }
}
