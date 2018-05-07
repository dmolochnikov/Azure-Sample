using System.Collections.Generic;

namespace BookStore.Models.Pagination
{
    /// <summary>
    /// Model for Index view
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// A collection of phones to show on Index page
        /// </summary>
        public IEnumerable<Phone> Phones { get; set; }
        
        /// <summary>
        /// Page data
        /// </summary>
        public PageInfo PageInfo { get; set; }
    }
}