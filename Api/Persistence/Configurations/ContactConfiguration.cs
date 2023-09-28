using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Persistence.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(er => er.Name).HasMaxLength(DbConstraints.ContactNameMaxLength).IsRequired();
            builder.Property(er => er.PhoneNumber).HasMaxLength(DbConstraints.ContactPhoneNumberMaxLength).IsRequired();
        }
    }
}
