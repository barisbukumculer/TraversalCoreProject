using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator:AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.GuideName).NotEmpty().WithMessage("İsim kısmını boş geçemezsiniz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz.");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Lütfen 50 Karakterlik bir açıklama giriniz.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen görsel seçiniz.");
        }
    }
}
