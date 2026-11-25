using LibraryManagement.Application.Services;
using LibraryManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bookService.GetAllBooks());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                return BadRequest("Book title is required.");
            }

            _bookService.AddBook(book);

            return Ok(book);
        }
    }
}