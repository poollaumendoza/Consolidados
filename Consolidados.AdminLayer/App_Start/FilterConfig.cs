﻿using System.Web;
using System.Web.Mvc;

namespace Consolidados.AdminLayer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}