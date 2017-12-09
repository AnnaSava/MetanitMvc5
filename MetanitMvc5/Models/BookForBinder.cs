using MetanitMvc5.Util;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MetanitMvc5.Models
{
    // Модель для ModelBinder
    [ModelBinder(typeof(BookModelBinder))] // Указать привязчик также можно в Global.asax
    public class BookForBinder
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