using System.Collections.Generic;

namespace BookStore.Models
{
    public class SearchResultsViewModel
    {
        public List<Book> Books { get; set; }

        public List<Student> Students { get; set; }

        public List<Player> Players { get; set; }
    }
}