using LibraryAPI.DTO;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepo repo;

        public ReviewController(IReviewRepo repo )
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
                ReviewDto reviewDto=repo.GetbyId(id);
                if (reviewDto != null)
                {
                    return Ok(reviewDto);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Create(ReviewDto reviewDto)
        {
            if (ModelState.IsValid)
            {
                int numOfRows = repo.creat(reviewDto);
                if (numOfRows > 0)
                {
                    return Ok("Added");
                }
                return BadRequest();
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Update(int id, ReviewDto reviewDto)
        {
            if (ModelState.IsValid)
            {
                ReviewDto review=repo.update(id,reviewDto);
                if(review != null)
                {
                    return Ok(review);
                }
                return NotFound();
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
                return NotFound();
            }
            return BadRequest(ModelState);
        }

    }
}
