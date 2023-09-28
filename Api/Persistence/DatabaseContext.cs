using Api.Persistence.Configurations;
using API.Entities;
using API.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Organization> Organization { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseEnumCheckConstraints();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
