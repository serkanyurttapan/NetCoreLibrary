using FluentValidation;
using FluentValidationApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Web.FluentValidators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Adres alanı gereklidir.");
            RuleFor(x => x.Province).NotEmpty().WithMessage("Adres alanı gereklidir.");
            RuleFor(x => x.PostCode).NotEmpty().WithMessage("Adres alanı gereklidir.").MaximumLength(4)
                .WithMessage("{PropertyName} alanı  en fazla {MaxLength} karakter olmalıdır.");

        }
    }
}
