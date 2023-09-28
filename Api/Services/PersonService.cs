using Api.Services.Interfaces;
using API.Entities;
using API.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class PersonService : IPersonService
    {
        private readonly IDatabaseContext _context;

        public PersonService(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Person> CreatePerson(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();

            return person;
        }

        public async Task<Person> GetPerson(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task UpdatePerson(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
