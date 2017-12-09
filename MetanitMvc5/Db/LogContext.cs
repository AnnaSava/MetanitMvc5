using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MetanitMvc5.Db
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Ip { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }

    public class LogContext : DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }
    }
}