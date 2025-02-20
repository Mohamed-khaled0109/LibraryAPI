using LibraryAPI.DTO;
using LibraryAPI.Models;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepo repo;

        public PaymentController(IPaymentRepo repo)
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
                PaymentDto paymentDto = repo.GetById(id);
                if (paymentDto != null)
                {
                    return Ok(paymentDto);
                }
                return NotFound("Not Found");
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Create(PaymentDto paymentDto)
        {
            if (ModelState.IsValid)
            {
                int numOfRows=repo.create(paymentDto);
                if (numOfRows > 0)
                {
                    return Ok("Added");
                }
                return BadRequest();
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Update(int id, PaymentDto paymentDto)
        {
            if (ModelState.IsValid)
            {
              var payment= repo.update(id, paymentDto);
                if(payment != null)
                {
                    return Ok(payment);
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
