﻿using System.Web.Mvc;

namespace BookStore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorHandler.AiHandleErrorAttribute());
            // filters.Add(new ErrorHandlerAttribute());
        }
    }
}