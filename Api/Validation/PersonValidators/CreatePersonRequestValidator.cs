using Api.Dtos.PersonDtos;
using Api.Enums;
using Api.Persistence.Configurations;
using FluentValidation;

namespace Api.Validation.PersonValidators
{
    public class CreatePersonRequestValidator : AbstractValidator<CreatePersonRequestDto>
    {
        public CreatePersonRequestValidator()
        {
            RuleFor(smr => smr.PhoneNumber)
                .NotEmpty()
                .MaximumLength(DbConstraints.ContactPhoneNumberMaxLength)
                .WithMessage("Incorrect format of the phone number.");

            RuleFor(smr => smr.Gender)
                .NotNull()
                .Must(g => Enum.IsDefined(typeof(Gender), g))
                .WithMessage("Invalid Gender value.");

            RuleFor(smr => smr.Name)
                .NotEmpty()
                .MaximumLength(DbConstraints.ContactNameMaxLength)
                .WithMessage("Choose name with smaller length.");
        }
    }
}
