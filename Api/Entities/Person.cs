using Api.Enums;

namespace API.Entities
{
    public class Person : Contact
    {
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
