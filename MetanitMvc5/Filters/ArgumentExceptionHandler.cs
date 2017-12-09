using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetanitMvc5.Filters
{
    public class ArgumentExceptionHandler : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is ArgumentException)
            {
                exceptionContext.Result = new ViewResult() { ViewName = "ArgumentException" };
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}