using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class BookModel
    {
        public class BookInfo
        {
            public int Id { get; set; }//ID
            public string Title { get; set; }//書名
            public string Author { get; set; }//作者
            public string ISBN { get; set; }//ISBN
            public string Category { get; set; }//類別
            public decimal Price { get; set; }//價格
            public DateTime ReleaseDate { get; set; }//上架日期
        }

        public class BookQuery
        {
            public string? Title { get; set; }//書名
            public string? Author { get; set; }//作者
            public string? ISBN { get; set; }//ISBN
            public string? Category { get; set; }//類別
            public decimal? MinPrice { get; set; }//最小價格
            public decimal? MaxPrice { get; set; }//最高價格
        }
    }
}
