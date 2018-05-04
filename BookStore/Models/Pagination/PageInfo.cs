using System;

namespace BookStore.Models.Pagination
{
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        // всего страниц
        public int TotalPages => (int) Math.Ceiling((decimal) TotalItems / PageSize);
    }
}