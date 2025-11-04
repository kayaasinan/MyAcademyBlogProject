using Blogy.Entity.Entities;
using FluentValidation;

namespace Blogy.Business.Validators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Bu alan boş bırakılamaz..!");
            RuleFor(x => x.BlogId).NotEmpty().WithMessage("Bu alan boş bırakılamaz..!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Bu alan boş bırakılamaz..!")
                                   .MaximumLength(250).WithMessage("İçerik 250 karakterden uzun olamaz");
        }
    }
}
