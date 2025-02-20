using LibraryAPI.DTO;
using LibraryAPI.Models;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepo repo;

        public ReservationController(IReservationRepo repo)
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
                ReservationDto reservationDto = repo.GetById(id);
                if (reservationDto != null)
                {
                    return Ok(reservationDto);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Create(ReservationDto reservationDto)
        {
            if (ModelState.IsValid)
            {
                int numOfRows = repo.create(reservationDto);
                if (numOfRows > 0)
                {
                    return Ok("Added");
                }
                return BadRequest();
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Update(int id, ReservationDto reservationDto)
        {
            if (ModelState.IsValid)
            {
                ReservationDto reservation=repo.update(id, reservationDto);
                if(reservation != null)
                {
                    return Ok(reservation);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult delete(int id)
        {
            if (ModelState.IsValid)
            {
                int numOfRows=repo.delete(id);
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
