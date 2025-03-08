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


        /// <summary>
        /// 取得所有書籍
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }


        /// <summary>
        /// 搜尋書籍
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        [HttpPost("SearchBooks")]
        public async Task<IActionResult> SearchBooks([FromBody] BookQuery queryDto)
        {
            var books = await _bookService.SearchBooksAsync(queryDto);
            return Ok(books);
        }


        /// <summary>
        /// 新增書籍
        /// </summary>
        /// <param name="newBook"></param>
        /// <returns></returns>
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] BookInfo newBook)
        {
            if (newBook == null)
            {
                return BadRequest("書籍資料空白");
            }

            await _bookService.AddBookAsync(newBook);
            return Ok(newBook.Title + " : 書籍新增成功");
        }


        /// <summary>
        /// 編輯書籍
        /// </summary>
        /// <param name="updatedBook"></param>
        /// <returns></returns>
        [HttpPut("EditBook")]
        public async Task<IActionResult> EditBook([FromBody] BookInfo updatedBook)
        {
            if (updatedBook == null)
            {
                return BadRequest("書籍資料空白");
            }

            await _bookService.EditBookAsync(updatedBook);
            return Ok("書籍更新成功");
        }


        /// <summary>
        /// 刪除書籍
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return Ok("書籍刪除成功");
        }

    }
}
