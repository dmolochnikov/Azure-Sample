using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BookStore.Models.Pagination;

namespace BookStore.Controllers
{
    public class PaginationController : ApiController
    {
        private readonly List<Phone> _phones;
        private const int PageSize = 3;

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

        [AcceptVerbs("GET")]
        public IHttpActionResult Index(int page = 1)
        {
            IEnumerable<Phone> phonesPerPages = _phones.Skip((page - 1) * PageSize).Take(PageSize);
            PageInfo pageInfo = new PageInfo {PageNumber = page, PageSize = PageSize, TotalItems = _phones.Count};
            IndexViewModel ivm = new IndexViewModel {PageInfo = pageInfo, Phones = phonesPerPages};
            return Ok(ivm);
        }
    }
}