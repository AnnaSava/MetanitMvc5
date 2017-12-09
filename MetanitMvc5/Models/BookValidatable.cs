using MetanitMvc5.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace MetanitMvc5.Models
{
    // Самовалидация
    public class BookValidatable : IValidatableObject
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Display(Name = "Год")]
        public int? Year { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                errors.Add(new ValidationResult("Введите название книги"));
            }
            if (string.IsNullOrWhiteSpace(this.Author))
            {
                errors.Add(new ValidationResult("Введите автора книги"));
            }
            if (this.Year == null || this.Year < 1700 || this.Year > 2000)
            {
                errors.Add(new ValidationResult("Недопустимый год"));
            }

            return errors;
        }
    }
}