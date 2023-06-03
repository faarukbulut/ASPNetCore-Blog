using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad soyad alanı boş geçilemez.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("E-posta alanı boş geçilemez.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Ad soyad alanı 2 karakterden küçük olamaz.");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Ad soyad alanı 50 karakteri geçemez.");

        }
    }
}
