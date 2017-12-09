using MetanitMvc5.Annotations;
using MetanitMvc5.Models;
using MetanitMvc5.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MetanitMvc5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ModelValidatorProviders.Providers.Add(new CustomValidatorProvider());

            ValueProviderFactories.Factories.Add(new BrowserValueProviderFactory());
            // Если возникнет необходимость поставить свою фабрику поставщика значений на первое место в списке
            // ValueProviderFactories.Factories.Insert(0, new BrowserValueProviderFactory());

            //ModelBinders.Binders.Add(typeof(BookForBinder), new BookModelBinder());

            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
