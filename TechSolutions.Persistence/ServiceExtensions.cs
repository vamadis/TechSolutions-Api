using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechSolutions.Application.Interfaces;
using TechSolutions.Persistence.Contexts;
using TechSolutions.Persistence.Repository;

namespace TechSolutions.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TechSolutionsDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(TechSolutionsDbContext).Assembly.FullName)));

            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient(typeof(IPermissionRepository), typeof(PermissionRepository));
            services.AddTransient(typeof(IPermissionTypeRepository), typeof(PermissionTypeRepository));
            #endregion
        }
    }
}
