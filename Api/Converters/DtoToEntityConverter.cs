using Api.Dtos.OrganizationDtos;
using Api.Dtos.PersonDtos;
using API.Entities;

namespace Api.Converters
{
    public class DtoToEntityConverter
    {
        //Person part
        public Person ConvertToEntity(CreatePersonRequestDto request)
        {
            return new Person();
        }

        public Organization ConvertToEntity(CreateOrganizationRequestDto request)
        {
            return new Organization();
        }
    }
}
