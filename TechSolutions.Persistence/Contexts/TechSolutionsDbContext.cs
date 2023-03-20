using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;
using TechSolutions.Domain.Entities;
using System;
using TechSolutions.Domain.Common;
using TechSolutions.Application.Interfaces;

namespace TechSolutions.Persistence.Contexts
{
    public class TechSolutionsDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        public TechSolutionsDbContext(DbContextOptions<TechSolutionsDbContext> options, IDateTimeService dateTime) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
        }

        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<TipoPermiso> TipoPermisos { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationTaken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationTaken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
