using Api.Enums;

namespace API.Entities
{
    public class Organization : Contact
    {
        public string? Website { get; set; }
        public string? Email { get; set; }
        public OrganizationType OrganizationType { get; set; }
    }
}
