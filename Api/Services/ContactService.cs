using Api.Services.Interfaces;
using API.Entities;
using API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class ContactService : IContactService
    {
        private readonly DatabaseContext _context;

        public ContactService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Contact>> GetAllContacts()
        {
            return await _context.Contacts.ToListAsync();
        }
    }
}
