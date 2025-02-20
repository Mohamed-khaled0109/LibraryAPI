using LibraryAPI.DTO;
using LibraryAPI.Models;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo repo;

        public CategoryController(ICategoryRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                return Ok(repo.GetAll());
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                CategoryDto categoryDto=repo.GetById(id);
                if (categoryDto != null)
                {
                    return Ok(categoryDto);
                }
                return NotFound("Not Found");
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            if (ModelState.IsValid)
            {
                CategoryDto categoryDto = repo.GetByName(name);
                if (categoryDto != null)
                {
                    return Ok(categoryDto);
                }
                return NotFound("Not Found");
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Create(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                int numOfRows=repo.create(categoryDto);
                if (numOfRows > 0)
                {
                    return Ok(categoryDto);
                }
                return BadRequest();
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Update(int id, CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
               CategoryDto category= repo.update(id, categoryDto);
                if (category != null)
                {
                    return Ok(category);
                }
                return NotFound("Not found");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                int numOfRows=repo.delete(id);
                if (numOfRows > 0)
                {
                    return Ok("Deleted");
                }
                return BadRequest("Not Found");
            }
            return BadRequest();
        }
    }
}
