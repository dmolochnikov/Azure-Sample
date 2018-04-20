using System.Web.Mvc;

namespace BookStore.App_Start
{
    public class ErrorHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Logger.Error("Error!!!", filterContext.Exception);
        }
    }
}