using System;

namespace BookStore.Models.Pagination
{
    /// <summary>
    /// Class that represents information about current page
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        /// Number of current page
        /// </summary>
        public int PageNumber { get; set; }
        
        /// <summary>
        /// The size of the page (number of objects on the page)
        /// </summary>
        public int PageSize { get; set; }
        
        /// <summary>
        /// Total number of objects
        /// </summary>
        public int TotalItems { get; set; }
        
        /// <summary>
        /// Total number of pages
        /// </summary>
        public int TotalPages => (int) Math.Ceiling((decimal) TotalItems / PageSize);
    }
}