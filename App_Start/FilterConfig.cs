﻿using System.Web;
using System.Web.Mvc;

namespace Demo_API_LOL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
