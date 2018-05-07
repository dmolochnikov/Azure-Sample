namespace BookStore.Models.Pagination
{
    /// <summary>
    /// Phone entity
    /// </summary>
    public class Phone
    {
        /// <summary>
        /// Phone Identifier
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Phone Model
        /// </summary>
        public string Model { get; set; }
        
        /// <summary>
        /// Phone Manufacturer
        /// </summary>
        public string Producer { get; set; }
    }
}