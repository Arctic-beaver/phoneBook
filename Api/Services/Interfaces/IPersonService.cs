using API.Entities;

namespace Api.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Person> CreatePerson(Person person);

        Task<Person> GetPerson(int id);

        Task<IEnumerable<Person>> GetAllPersons();

        Task UpdatePerson(Person person);

        Task DeletePerson(int id);
    }
}
