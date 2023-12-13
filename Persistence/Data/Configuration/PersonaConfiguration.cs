using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        // Configure entity properties, relationships, etc.
        builder.ToTable("Persona");
        builder.HasOne(p => p.TipoPersona)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdTPersona);
        builder.HasOne(p => p.CategoriaPersona)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdCat);    
        builder.HasOne(p => p.Ciudad)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdCiudad);
    }
}