using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechSolutions.Domain.Entities;

namespace TechSolutions.Persistence.Configuration
{
    public class PermissionTypeConfig : IEntityTypeConfiguration<TipoPermiso>
    {
        public void Configure(EntityTypeBuilder<TipoPermiso> builder)
        {
            builder.ToTable("TipoPermiso");

            builder.Property(e => e.Created).HasColumnType("datetime");

            builder.Property(e => e.Descripcion)
                .IsRequired()
            .HasMaxLength(50);

            builder.Property(e => e.LastModified).HasColumnType("datetime");
        }
    }
}
