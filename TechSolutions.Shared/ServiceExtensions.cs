using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechSolutions.Application.Interfaces;
using TechSolutions.Shared.Services;

namespace TechSolutions.Shared
{
    public static class ServiceExtensions
    {
        public static void AddSharedInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
