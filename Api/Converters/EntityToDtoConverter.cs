namespace Api.Converters
{
    public class EntityToDtoConverter
    {
        public ContactToFrontDto ConvertToDto(Contact request)
        {
            return new ContactToFrontDto();
        }

        public PersonToFrontDto ConvertToDto(Person request)
        {
            return new PersonToFrontDto();
        }

        public OrganizationToFrontDto ConvertToDto(Organization request)
        {
            return new OrganizationToFrontDto();
        }
    }
}
