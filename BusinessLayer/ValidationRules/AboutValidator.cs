﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz.");
            RuleFor(x=>x.Description).MinimumLength(50).WithMessage("Lütfen 50 Karakterlik bir açıklama giriniz.");
            RuleFor(x=>x.Description).MaximumLength(100).WithMessage("Lütfen açıklamayı kısaltınız.");
            RuleFor(x=>x.Image).NotEmpty().WithMessage("Lütfen görsel seçiniz.");
        }
    }
}
