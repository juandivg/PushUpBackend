using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
{
    public void Configure(EntityTypeBuilder<Programacion> builder)
    {
        // Configure entity properties, relationships, etc.
        builder.ToTable("Programacion");
        builder.HasOne(p => p.Contrato)
            .WithMany(p => p.Programaciones)
            .HasForeignKey(p => p.idContrato);
        builder.HasOne(p => p.Turno)
            .WithMany(p => p.Programaciones)
            .HasForeignKey(p => p.idTurno);
        builder.HasOne(p => p.Empleado)
            .WithMany(p => p.Programaciones)
            .HasForeignKey(p => p.idEmpleado);
        
    }
}