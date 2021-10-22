using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
  public  class WriterValidator: AbstractValidator<Writer>

    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre adresi boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakterlik veri girişi yapın");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapın");

            RuleFor(x => x.WriterPassword).Must(IsWriterPasswordValid).WithMessage("Parola en az 6 karakter olmalıdır, en az bir küçük harf bir büyük harf ve rakam olmalıdır");

        }

        private bool IsWriterPasswordValid(string arg)
        {
          
                try
                {
                    Regex reg =
                        new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]{6,}$");

                return reg.IsMatch(arg);
            }
                catch
                {
                    return false;
                }
            }
        }
    }

