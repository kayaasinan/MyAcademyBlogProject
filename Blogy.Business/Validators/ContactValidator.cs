using Blogy.Entity.Entities;
using FluentValidation;

namespace Blogy.Business.Validators
{
    public class ContactValidator : AbstractValidator<ContactUs>
    {
        public ContactValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Ad-Soyad alanı boş bırakılamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesaj konusu alanı boş bırakılamaz")
                                   .MinimumLength(5).WithMessage("Mesaj konusu için en az 5 karekterlik veri girişi yapınız")
                                   .MaximumLength(40).WithMessage("Mesaj konusu için en fazla 40 karekterlik veri girişi yapınız");
            RuleFor(x => x.Body).NotEmpty().WithMessage("Mesaj içeriği alanı boş bırakılamaz")
                                .MinimumLength(10).WithMessage("Mesaj içeriği için en az 10 karekterlik veri girişi yapınız")
                                 .MaximumLength(250).WithMessage("Mesaj içeriği için en fazla 250 karekterlik veri girişi yapınız");
        }
    }
}
