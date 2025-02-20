using LibraryAPI.DTO;
using LibraryAPI.Models;
using LibraryAPI.Services;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepo authorRepo;

        public AuthorController(IAuthorRepo authorRepo)
        {
            this.authorRepo = authorRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                return Ok(authorRepo.GetAuthors());
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var author=authorRepo.GetById(id);
                if (author != null)
                {
                    return Ok(author);
                }
                return BadRequest("Not found");
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            if (ModelState.IsValid)
            {
                var author = authorRepo.GetByName(name);
                if (author != null)
                {
                    return Ok(author);
                }
                return BadRequest("Not found");
            }
            return BadRequest(ModelState);

        }
        [HttpPost]
        public IActionResult create(AuthorDto authorDto)
        {
            if (ModelState.IsValid)
            {
                int numOfRows= authorRepo.creat(authorDto);
                if (numOfRows > 0)
                {
                    return Ok("Added");
                }
                return BadRequest();
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Update(int Id, AuthorDto authorDto)
        {
            if (ModelState.IsValid)
            {
              var auther= authorRepo.Update(Id, authorDto);
                if(auther != null)
                {
                    return Ok(auther);
                }
                return BadRequest("Not Found");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            if(ModelState.IsValid)
            {
               int numOfRows= authorRepo.delete(Id);
                if (numOfRows > 0)
                {
                    return Ok("Deleted");
                }
                return BadRequest();

            }
            return BadRequest(ModelState);
        }
    }
}
