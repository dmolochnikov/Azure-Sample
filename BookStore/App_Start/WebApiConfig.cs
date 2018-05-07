using System.Web.Http;

namespace BookStore
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
                new { controller = "Pagination", action = "GetPhones", id = RouteParameter.Optional });
        }
    }
}