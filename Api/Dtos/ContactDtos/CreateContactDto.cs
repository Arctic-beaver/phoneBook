namespace Api.Dtos.ContactDtos
{
    public class CreateContactDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Comments { get; set; }
    }
}
