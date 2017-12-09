using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetanitMvc5.Filters
{
    public class CustomResultAttribute : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {

            filterContext.HttpContext.Response.Write("Время текущего запроса HTTP: " + filterContext.HttpContext.Timestamp);
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {

            filterContext.HttpContext.Response.Write("Текущий пользователь: " + filterContext.HttpContext.User.Identity.Name);
        }
    }
}