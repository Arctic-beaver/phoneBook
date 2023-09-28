using API.Entities;

namespace Api.Services.Interfaces
{
    public interface IContactService
    {
        Task<Contact[]> GetAllContacts();
    }
}
