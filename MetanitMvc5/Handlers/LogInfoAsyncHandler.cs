using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MetanitMvc5.Db;
using System.Data.Entity;

namespace MetanitMvc5.Handlers
{
    public class LogInfoAsyncHandler : HttpTaskAsyncHandler
    {
        public override async Task ProcessRequestAsync(HttpContext context)
        {
            string idString = context.Request.Url.Segments[2];
            int id;
            Int32.TryParse(idString, out id);
            Visitor user;
            string result = "";
            using (LogContext db = new LogContext())
            {
                user = await db.Visitors.FindAsync(id);
            }
            if (user != null)
            {
                result += "<p>Id=" + user.Id.ToString() + " Name: " + user.Ip + "</p>";
            }
            context.Response.Write(result);
        }
    }
}