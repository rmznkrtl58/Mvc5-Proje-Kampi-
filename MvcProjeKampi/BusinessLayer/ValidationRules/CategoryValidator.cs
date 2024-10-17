using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidator:AbstractValidator<Category>//using.fluent
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Bırakamazsın");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori Adı Minimum 3 karakterli olmalıdır");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori Adı Maximum 50 Karakter olmalıdır");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklamasını Boş Bırakamazsın");
            RuleFor(x => x.CategoryDescription).MinimumLength(10).WithMessage("Kategori Açıklaması Minimum 10 karakterli olmalıdır");
            RuleFor(x => x.CategoryDescription).MaximumLength(300).WithMessage("Kategori Açıklaması Maximum 300 Karakter olmalıdır");
        }
    }
}
