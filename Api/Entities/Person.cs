namespace API.Entities
{
    public class Person : Contact
    {
        public DateTime BirthDate { get; set; }
        public string? Gender { get; set; }
    }
}
