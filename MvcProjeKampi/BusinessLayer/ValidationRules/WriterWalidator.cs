using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterWalidator:AbstractValidator<Writer>
    {
        public WriterWalidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Bırakamazsın");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Yazar Adı Minimum 3 karakterli olmalıdır");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar Adı Maximum 50 Karakter olmalıdır");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadı Boş Bırakamazsın");
            RuleFor(x => x.WriterSurName).MinimumLength(4).WithMessage("Yazar Soyadı Minimum 10 karakterli olmalıdır");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Yazar Soyadı Maximum 300 Karakter olmalıdır");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Yazar Resmi Boş Bırakamazsın");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar Mailini Boş Bırakamazsın");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar Şifresini Boş Bırakamazsın");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar Hakkımda kısmını Boş Bırakamazsın");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Ünvanı kısmını Boş Bırakamazsın");
        }
    }
}
