using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace API.Persistence.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<Person> Persons { get; set; }
        DbSet<Organization> Organization { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        DatabaseFacade Database { get; }
    }
}
