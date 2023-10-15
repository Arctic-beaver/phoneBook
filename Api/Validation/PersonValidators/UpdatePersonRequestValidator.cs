using Api.Dtos.PersonDtos;
using Api.Enums;
using Api.Persistence.Configurations;
using FluentValidation;

namespace Api.Validation.PersonValidators
{
    public class UpdatePersonRequestValidator : AbstractValidator<UpdatePersonRequestDto>
    {
        public UpdatePersonRequestValidator()
        {
            RuleFor(smr => smr.Id).NotEmpty();

            RuleFor(smr => smr.PhoneNumber)
                .MaximumLength(DbConstraints.ContactPhoneNumberMaxLength)
                .WithMessage("Incorrect format of the phone number.");

            RuleFor(smr => smr.Gender)
                .Must(g => g == null || Enum.IsDefined(typeof(Gender), g))
                .WithMessage("Invalid Gender value.");

            RuleFor(smr => smr.Name)
                .MaximumLength(DbConstraints.ContactNameMaxLength)
                .WithMessage("Choose name with smaller length.");
        }
    }
}
