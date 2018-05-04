using System.Collections.Generic;

namespace BookStore.Models.Pagination
{
    public class IndexViewModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}