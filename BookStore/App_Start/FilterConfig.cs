using System.Web.Mvc;
using BookStore.App_Start;

namespace BookStore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // filters.Add(new ErrorHandlerAttribute());
        }
    }
}