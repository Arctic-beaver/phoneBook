using Api.Dtos.ContactDtos;
using Api.Enums;

namespace Api.Dtos.OrganizationDtos
{
    public class CreateOrganizationRequestDto : CreateContactDto
    {
        public string? Website { get; set; }
        public string? Email { get; set; }
        public OrganizationType OrganizationType { get; set; }
    }
}
