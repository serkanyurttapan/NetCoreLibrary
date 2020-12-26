using FluentValidation;
using FluentValidationApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";

        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Email alanı doğru formatta olmalıdır");

            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60).WithMessage
                ("Age alanı 18 ile 60 arasında olmalıdır.");

            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Yaşınız 18 yaşından büyük olmalıdır.");
            // Address ile Customer arasında 1-n ilişki olduğundan RuleForEach kullanıldı.
            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
            //tekil olsaydı bu şekilde kullanılabilirdi.
            //RuleFor(x => x.Addresses).SetValidator(new AddressValidator());
            RuleFor(x => x.Gender).NotEmpty().WithMessage("{PropertyName} boş geçilemez").IsInEnum().WithMessage("{PropertyName} Erkek=1 veya Kadın=2 olmalıdır");
        }
    }
}