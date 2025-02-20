using LibraryAPI.DTO;
using LibraryAPI.Models;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly IBorrowingRepo repo;

        public BorrowingController(IBorrowingRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                return Ok(repo.GetBorrowings());
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                BorrowingDto borrowing=repo.GetById(id);
                if(borrowing != null)
                {
                    return Ok(borrowing);
                }
                return NotFound("Not Found");
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Create(BorrowingDto borrowingDto)
        {
            if (ModelState.IsValid)
            {
                int numOfRows = repo.creat(borrowingDto);
                if (numOfRows > 0)
                {
                    return Ok("Added");
                }
                return BadRequest();
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Update(int id, BorrowingDto borrowingDto)
        {
            if (ModelState.IsValid)
            {
                BorrowingDto borrowing=repo.update(id,borrowingDto);
                if(borrowing != null)
                {
                    return Ok(borrowing);
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
               int numOfRows= repo.delete(id);
                if(numOfRows > 0)
                {
                    return Ok("Deleted");

                }
                return NotFound("Not found");
            }
            return BadRequest(ModelState);
        }
    }
}
