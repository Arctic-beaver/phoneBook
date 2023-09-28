using Api.Dtos.ContactDtos;
using Api.Enums;

namespace Api.Dtos.PersonDtos
{
    public class UpdatePersonRequestDto : UpdateContactDto
    {
        public DateTime? BirthDate { get; set; }
        public Gender? Gender { get; set; }
    }
}
