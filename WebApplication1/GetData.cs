using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApplication1.BookModel;

namespace WebApplication1
{
    public class GetData
    {
        /// <summary>
        /// 假資料  抓取所有書籍
        /// </summary>
        /// <returns></returns>
        public static List<BookInfo> GetSQLData()
        {
            return new List<BookInfo>
        {
            new BookInfo { Id = 1, Title = "C# Programming", Author = "John Doe", ISBN = "123456789", Category = "Programming", Price = 199.99m },
            new BookInfo { Id = 2, Title = "ASP.NET Core", Author = "Jane Smith", ISBN = "987654321", Category = "Programming", Price = 149.99m },
            new BookInfo { Id = 3, Title = "Clean Code", Author = "Robert C. Martin", ISBN = "555555555", Category = "Programming", Price = 249.99m }
        };

        }
    }
}
