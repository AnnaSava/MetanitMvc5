using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MetanitMvc5.Db
{
    public class Mvc5Context : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
    }

    public class Phone
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}