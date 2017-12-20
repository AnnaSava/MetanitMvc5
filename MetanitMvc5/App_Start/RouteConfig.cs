using MetanitMvc5.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MetanitMvc5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Маршрут с кастомным обработчиком запроса
            //routes.Add("handler", new Route("handler/{*path}", new CustomRouteHandler()));

            // Маршрут с кастомным асинхронным обработчиком запроса
            //routes.Add("LogInfo", new Route("Log/{id}", new CustomAsyncRouteHandler()));

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        // обработчик маршрута
        class CustomRouteHandler : IRouteHandler
        {
            public IHttpHandler GetHttpHandler(RequestContext requestContext)
            {
                return new UserInfoHandler();
            }
        }

        //асинхронный обработчик маршрута
        class CustomAsyncRouteHandler : IRouteHandler
        {
            public IHttpHandler GetHttpHandler(RequestContext requestContext)
            {
                return new LogInfoAsyncHandler();
            }
        }
    }
}
