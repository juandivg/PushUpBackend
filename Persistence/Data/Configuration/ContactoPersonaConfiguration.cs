using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ContactoPersonaConfiguration : IEntityTypeConfiguration<ContactoPersona>
{
    public void Configure(EntityTypeBuilder<ContactoPersona> builder)
    {
        // Configure entity properties, relationships, etc.
        builder.ToTable("ContactoPersona");
        builder.HasOne(p => p.Persona)
            .WithMany(p => p.ContactoPersonas)
            .HasForeignKey(p => p.idPersona);
    }
}