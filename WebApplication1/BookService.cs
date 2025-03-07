using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApplication1.BookModel;
using static WebApplication1.BookService;

namespace WebApplication1
{
    public class BookService : IBookService
    {

        public interface IBookService
        {
            Task<List<BookInfo>> SearchBooksAsync(BookQuery queryDto);
        }



        public async Task<List<BookInfo>> SearchBooksAsync(BookQuery queryDto)
        {
            // 假資料庫：模擬從資料庫中拉取的資料
            var bookInfos = new List<BookInfo>
    {
        new BookInfo { Id = 1, Title = "C# Programming", Author = "John Doe", ISBN = "123456789", Category = "Programming", Price = 199.99m },
        new BookInfo { Id = 2, Title = "ASP.NET Core", Author = "Jane Smith", ISBN = "987654321", Category = "Programming", Price = 149.99m },
        new BookInfo { Id = 3, Title = "Clean Code", Author = "Robert C. Martin", ISBN = "555555555", Category = "Programming", Price = 249.99m }
    };

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



    }
}
