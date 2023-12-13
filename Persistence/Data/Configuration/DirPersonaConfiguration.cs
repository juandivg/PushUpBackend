using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class DirPersonaConfiguration : IEntityTypeConfiguration<DirPersona>
{
    public void Configure(EntityTypeBuilder<DirPersona> builder)
    {
        // Configure entity properties, relationships, etc.tota
        builder.ToTable("DirPersona");
        builder.HasOne(p => p.Persona)
            .WithMany(p => p.dirPersonas)
            .HasForeignKey(p => p.idPersona);
        builder.HasOne(p => p.TipoDireccion)
            .WithMany(p => p.DirPersonas)
            .HasForeignKey(p => p.idTDireccion);
            
    }
}