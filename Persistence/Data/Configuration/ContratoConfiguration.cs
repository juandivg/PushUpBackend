using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        // Configure entity properties, relationships, etc.
        builder.ToTable("Contrato");
        builder.HasOne(p => p.Cliente)
            .WithMany(p => p.ContratosCliente)
            .HasForeignKey(p => p.IdCliente);
        builder.HasOne(p => p.Empleado)
            .WithMany(p => p.ContratosEmpleado)
            .HasForeignKey(p => p.IdEmpleado);
        builder.HasOne(p => p.Estado)
            .WithMany(p => p.Contratos)
            .HasForeignKey(p => p.IdEstado);

    }
}