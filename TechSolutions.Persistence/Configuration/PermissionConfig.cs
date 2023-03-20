using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechSolutions.Domain.Entities;

namespace TechSolutions.Persistence.Configuration
{
    public class PermissionConfig : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.ToTable("Permiso");

            builder.Property(e => e.ApellidosEmpleado)
                .IsRequired()
            .HasMaxLength(50);

            builder.Property(e => e.Created).HasColumnType("datetime");

            builder.Property(e => e.FechaPermiso).HasColumnType("datetime");

            builder.Property(e => e.LastModified).HasColumnType("datetime");

            builder.Property(e => e.NombreEmpleado)
                .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(d => d.TipoPermisoNavigation)
                .WithMany(p => p.Permisos)
                .HasForeignKey(d => d.TipoPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permiso_TipoPermiso");
        }
    }
}
