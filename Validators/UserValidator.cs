using FluentValidation;
using InstrumentRentalApi.Models; 

namespace InstrumentRentalApi.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Ім'я користувача є обов'язковим.")
                .MinimumLength(3).WithMessage("Ім'я має бути не менше 3 символів.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email є обов'язковим.")
                .EmailAddress().WithMessage("Некоректний формат Email.");
        }
    }
}