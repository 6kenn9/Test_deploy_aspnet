using FluentValidation;
using InstrumentRentalApi.Models; 

namespace InstrumentRentalApi.Validators
{
    public class InstrumentValidator : AbstractValidator<Instrument>
    {
        public InstrumentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Назва інструменту є обов'язковою.")
                .MinimumLength(2).WithMessage("Назва має бути не менше 2 символів.");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Вказано недійсний тип інструменту.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("ID категорії є обов'язковим.");
        }
    }
}