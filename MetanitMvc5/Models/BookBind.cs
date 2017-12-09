using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MetanitMvc5.Models
{
    [Bind(Exclude = "Year")]
    public class BookBind
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Display(Name = "Год")]
        public int Year { get; set; }
    }
}