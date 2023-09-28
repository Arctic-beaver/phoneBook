using Api.Services.Interfaces;
using API.Entities;
using API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly DatabaseContext _context;

        public OrganizationService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Organization> CreateOrganization(Organization organization)
        {
            await _context.Organizations.AddAsync(organization);
            await _context.SaveChangesAsync();

            return organization;
        }

        public async Task<Organization> GetOrganization(int id)
        {
            return await _context.Organizations.FindAsync(id);
        }

        public async Task<IEnumerable<Organization>> GetAllOrganizations()
        {
            return await _context.Organizations.ToListAsync();
        }

        public async Task UpdateOrganization(Organization organization)
        {
            _context.Organizations.Update(organization);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrganization(int id)
        {
            var organization = await _context.Organizations.FindAsync(id);
            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();
        }
    }
}
