using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MetanitMvc5.Models
{
    // Класс без валидации
    public class ClearBook
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Display(Name = "Год")]
        public int Year { get; set; }
    }
}