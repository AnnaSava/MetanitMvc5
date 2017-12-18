using MetanitMvc5.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetanitMvc5.Modules
{
    public class HandlerSelectionModule : IHttpModule
    {
        public void Init(HttpApplication app)
        {
            app.PostResolveRequestCache += (src, args) =>
            {
                if (string.Equals((string)app.Context.Request.RequestContext.RouteData.Values["controller"],
                    "Home", StringComparison.OrdinalIgnoreCase) &&
                        string.Equals((string)app.Context.Request.RequestContext.RouteData.Values["action"],
                        "RemapHandler", StringComparison.OrdinalIgnoreCase))
                {
                    app.Context.RemapHandler(new UserInfoHandler());
                }
            };
        }
        public void Dispose()
        { }
    }
}