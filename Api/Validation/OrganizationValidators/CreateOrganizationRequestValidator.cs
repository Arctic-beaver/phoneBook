using Api.Dtos.OrganizationDtos;
using Api.Enums;
using Api.Persistence.Configurations;
using FluentValidation;

namespace Api.Validation.OrganizationValidators
{
    public class CreateOrganizationRequestValidator : AbstractValidator<CreateOrganizationRequestDto>
    {
        public CreateOrganizationRequestValidator()
        {
            RuleFor(smr => smr.PhoneNumber)
                .NotEmpty()
                .MaximumLength(DbConstraints.ContactPhoneNumberMaxLength)
                .WithMessage("Incorrect format of the phone number.");

            RuleFor(smr => smr.OrganizationType)
                .NotNull()
                .Must(g => Enum.IsDefined(typeof(OrganizationType), g))
                .WithMessage("Invalid OrganizationType value.");

            RuleFor(smr => smr.Name)
                .NotEmpty()
                .MaximumLength(DbConstraints.ContactNameMaxLength)
                .WithMessage("Choose name with smaller length.");
        }
    }
}
