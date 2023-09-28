using API.Entities;

namespace Api.Services.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContacts();
    }
}
