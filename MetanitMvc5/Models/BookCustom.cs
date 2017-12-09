using MetanitMvc5.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace MetanitMvc5.Models
{
    public class BookCustom
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [CustomAuthors(new string[] { "Л. Толстой", "А. Пушкин", "И. Тургенев" }, ErrorMessage = "Недопустимый автор")]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Год")]
        [Range(1700, 2000, ErrorMessage = "Недопустимый год")]
        public int Year { get; set; } 
    }
}