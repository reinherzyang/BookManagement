using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApplication1.BookModel;
using static WebApplication1.BookService;
using static WebApplication1.GetData;

namespace WebApplication1
{
    public class BookService : IBookService
    {
        /// <summary>
        /// interface
        /// </summary>
        public interface IBookService
        {
            Task<List<BookInfo>> SearchBooksAsync(BookQuery queryDto);
            Task<List<BookInfo>> GetAllBooksAsync();
            Task<BookInfo> AddBookAsync(BookInfo newBook);
            Task EditBookAsync(BookInfo updatedBook);
            Task DeleteBookAsync(int id);
        }

        /// <summary>
        /// 取得所有書籍
        /// </summary>
        /// <returns></returns>
        public async Task<List<BookInfo>> GetAllBooksAsync()
        {
            // 假資料
            List<BookInfo> bookInfos = GetSQLData();
            return await Task.FromResult(bookInfos);
        }

        /// <summary>
        /// 搜尋書籍
        /// </summary>
        /// <param name="queryDto"></param>
        /// <returns></returns>
        public async Task<List<BookInfo>> SearchBooksAsync(BookQuery queryDto)
        {
            // 假資料
            List<BookInfo> bookInfos = GetSQLData();

            // 使用 LINQ 進行篩選
            var query = bookInfos.AsQueryable();

            if (!string.IsNullOrEmpty(queryDto.Title))
                query = query.Where(b => b.Title.Contains(queryDto.Title));

            if (!string.IsNullOrEmpty(queryDto.Author))
                query = query.Where(b => b.Author.Contains(queryDto.Author));

            if (!string.IsNullOrEmpty(queryDto.ISBN))
                query = query.Where(b => b.ISBN == queryDto.ISBN);

            if (!string.IsNullOrEmpty(queryDto.Category))
                query = query.Where(b => b.Category == queryDto.Category);

            if (queryDto.MinPrice.HasValue)
                query = query.Where(b => b.Price >= queryDto.MinPrice.Value);

            if (queryDto.MaxPrice.HasValue)
                query = query.Where(b => b.Price <= queryDto.MaxPrice.Value);

            // 返回篩選後的結果
            return await Task.FromResult(query.ToList());
        }

        /// <summary>
        /// 新增書籍
        /// </summary>
        /// <param name="newBook"></param>
        /// <returns></returns>
        public async Task<BookInfo> AddBookAsync(BookInfo newBook)
        {
            // 假資料
            List<BookInfo> bookInfos = GetSQLData();

            //新增時驗證是否有重複ISBN
            if (bookInfos.Any(b => b.ISBN == newBook.ISBN))
            {
                throw new InvalidOperationException("書籍 ISBN 已存在，請使用不同的 ISBN");
            }

            //執行新增書籍的SQL語法

            return await Task.FromResult(newBook);
        }


        /// <summary>
        /// 編輯書籍
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedBook"></param>
        /// <returns></returns>
        public async Task EditBookAsync(BookInfo updatedBook)
        {
            // 使用SQL驗證ISBN是否重複

            if (false)
            {
                throw new InvalidOperationException("書籍 ISBN 已存在，請使用不同的 ISBN");
            }

            //執行更新書籍的SQL語法

            await Task.CompletedTask;
        }


        /// <summary>
        /// 刪除書籍
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteBookAsync(int id)
        {
            // 假資料
            List<BookInfo> bookInfos = GetSQLData();

            //驗證是否有該書籍
            var getingBook = bookInfos.FirstOrDefault(b => b.Id == id);
            if (getingBook == null)
            {
                throw new InvalidOperationException("找不到該書籍!");
            }

            //使用SQL語法將這筆資料的Appear狀態更新為刪除

            await Task.CompletedTask;
        }

    }
}
