using MetanitMvc5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MetanitMvc5.Annotations
{
    public class NotAllowedAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            BookNotAllowed b = value as BookNotAllowed;
            if (b.Name == "Преступление и наказание" && b.Author == "Ф. Достоевский" && b.Year == 1866)
            {
                return false;
            }
            return true;
        }
    }
}