using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MetanitMvc5.Annotations
{
    public class CustomAuthorsAttribute: ValidationAttribute
    {
        //массив для хранения допустимых авторов
        private static string[] myAuthors;

        public CustomAuthorsAttribute(string[] Authors)
        {
            myAuthors = Authors;
        }
 
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string strval = value.ToString();
                for (int i = 0; i < myAuthors.Length; i++)
                {
                    if (strval == myAuthors[i])
                        return true;
                }
            }
            return false;
        }
    }

}