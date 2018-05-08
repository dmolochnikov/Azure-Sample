using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BookStore.Models.Pagination;
using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;

namespace BookStore.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Web API controller to show pagination of a list
    /// </summary>
    public class PaginationController : ApiController
    {
        private readonly List<Phone> _phones;
        private const int PageSize = 3;

        /// <inheritdoc />
        /// <summary>
        /// Controller constructor (creates hard-coded list of phones)
        /// </summary>
        public PaginationController()
        {
            _phones = new List<Phone>
            {
                new Phone {Id = 1, Model = "Samsung Galaxy III", Producer = "Samsung"},
                new Phone {Id = 2, Model = "Samsung Ace II", Producer = "Samsung"},
                new Phone {Id = 3, Model = "HTC Hero", Producer = "HTC"},
                new Phone {Id = 4, Model = "HTC One S", Producer = "HTC"},
                new Phone {Id = 5, Model = "HTC One X", Producer = "HTC"},
                new Phone {Id = 6, Model = "LG Optimus 3D", Producer = "LG"},
                new Phone {Id = 7, Model = "Nokia N9", Producer = "Nokia"},
                new Phone {Id = 8, Model = "Samsung Galaxy Nexus", Producer = "Samsung"},
                new Phone {Id = 9, Model = "Sony Xperia X10", Producer = "SONY"},
                new Phone {Id = 10, Model = "Samsung Galaxy II", Producer = "Samsung"}
            };
        }

        /// <summary>
        /// Get first N phones
        /// </summary>
        /// <remarks>
        /// A list of phones with N elements
        /// </remarks>
        /// <param name="page">number of page to display</param>
        /// <returns>a page with phones</returns>
        // [Route("api/phones")]
        // [ResponseType(typeof(IndexViewModel))]
        [SwaggerResponseHeader(HttpStatusCode.OK, "MyCustomHeader", "string", "A collection of mobile phones")]
        [SwaggerResponse(HttpStatusCode.OK, "Success!", typeof(IndexViewModel))]
        public IHttpActionResult GetPhones(int page = 1)
        {
            IEnumerable<Phone> phonesPerPages = _phones.Skip((page - 1) * PageSize).Take(PageSize);
            PageInfo pageInfo = new PageInfo {PageNumber = page, PageSize = PageSize, TotalItems = _phones.Count};
            IndexViewModel ivm = new IndexViewModel {PageInfo = pageInfo, Phones = phonesPerPages};
            return Ok(ivm);
        }
    }
}