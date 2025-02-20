using LibraryAPI.DTO;
using LibraryAPI.Models;
using LibraryAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace LibraryAPI.Services
{
    public class CategoryRepo: ICategoryRepo
    {
        private readonly Context context;

        public CategoryRepo(Context context)
        {
            this.context = context;
        }

        public List<Category> GetAll()
        {
            return context.categories.ToList();
        }

        public CategoryDto GetById(int id)
        {
            var category = context.categories.FirstOrDefault(C=>C.Id==id);
            var categoryDto= new CategoryDto();
            
            categoryDto.Name = category.Name;
            categoryDto.Description = category.Description;

            foreach(var item in category.books)
            {
                categoryDto.Books.Add(item.Name.ToString());
            }
            return categoryDto;
        }

        public CategoryDto GetByName(string name)
        {
            var category = context.categories.FirstOrDefault(C => C.Name == name);
            var categoryDto = new CategoryDto();

            categoryDto.Name = category.Name;
            categoryDto.Description = category.Description;

            foreach (var item in category.books)
            {
                categoryDto.Books.Add(item.Name.ToString());
            }
            return categoryDto;
        }

        public int create(CategoryDto categoryDto)
        {
            var category = new Category();

            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;
            context.categories.Add(category);
            return context.SaveChanges();
        }

        public CategoryDto update(int id,CategoryDto categoryDto)
        {
            var category = context.categories.FirstOrDefault(C => C.Id == id);

            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;
            
             context.SaveChanges();
            return categoryDto;
        }

        public int delete (int id)
        {
            var category = context.categories.FirstOrDefault(C => C.Id == id);
            context.categories.Remove(category);
            return context.SaveChanges();
        }


    }
}
