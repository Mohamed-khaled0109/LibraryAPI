using LibraryAPI.DTO;
using LibraryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo repo;

        public BookController(IBookRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                return Ok(repo.GetBooks());
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var book=repo.GetById(id);
                if (book != null)
                {
                    return Ok(book);
                }
                return BadRequest("Not Found");
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            if (ModelState.IsValid)
            {
                var book = repo.GetByName(name);
                if (book != null)
                {
                    return Ok(book);
                }
                return BadRequest("Not Found");
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        public IActionResult Create(BookDto bookDto)
        {
            if (ModelState.IsValid)
            {
               int numOfRows= repo.creat(bookDto);
                if (numOfRows > 0)
                {
                    return Ok("Added");
                }
                return BadRequest();
            }
            return BadRequest(ModelState);

        }
        [HttpPut]
        public IActionResult Update(int id, BookDto bookDto)
        {
            if(ModelState.IsValid)
            {
                BookDto book=repo.update(id, bookDto);
                if(book != null)
                {
                    return Ok(book);
                }
                return BadRequest("Not found");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                int numOfRows=repo.Delete(id);
                if (numOfRows > 0)
                {
                    return Ok("Deleted");
                }
                return BadRequest();
            }
            return BadRequest(ModelState);
        }

        [HttpGet("download/{fileName}")]
        public IActionResult DownloadBook(string fileName)
        {
            if (ModelState.IsValid)
            {
                var filePath = Path.Combine("wwwroot/books", fileName);
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound(new { message = "الكتاب غير موجود" });
                }

                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/pdf", fileName);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadBook(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "يرجى اختيار ملف صالح." });
            }

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/books");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { message = "تم رفع الكتاب بنجاح", fileName = file.FileName });
        }

    }
}
