using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApplication1.BookModel;
using static WebApplication1.BookService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpPost("search")]
        public async Task<IActionResult> SearchBooks([FromBody] BookQuery queryDto)
        {
            var books = await _bookService.SearchBooksAsync(queryDto);
            return Ok(books);
        }

    }
}
