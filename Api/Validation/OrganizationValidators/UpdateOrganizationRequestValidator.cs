using Api.Dtos.OrganizationDtos;
using Api.Enums;
using Api.Persistence.Configurations;
using FluentValidation;

namespace Api.Validation.OrganizationValidators
{
    public class UpdateOrganizationRequestValidator : AbstractValidator<UpdateOrganizationRequestDto>
    {
        public UpdateOrganizationRequestValidator()
        {
            RuleFor(smr => smr.Id).NotEmpty();

            RuleFor(smr => smr.PhoneNumber)
                .MaximumLength(DbConstraints.ContactPhoneNumberMaxLength)
                .WithMessage("Incorrect format of the phone number.");

            RuleFor(smr => smr.OrganizationType)
                .Must(g => g == null || Enum.IsDefined(typeof(OrganizationType), g))
                .WithMessage("Invalid OrganizationType value.");

            RuleFor(smr => smr.Name)
                .MaximumLength(DbConstraints.ContactNameMaxLength)
                .WithMessage("Choose name with smaller length.");
        }
    }
}
