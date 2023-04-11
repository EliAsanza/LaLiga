using LaLiga.Domain.Interfaces.Repositories;
using LaLiga.Infraestructure.Persistence;
using LaLiga.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LaLiga.Infraestructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LaLigaContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("LaLiga"),
                b => b.MigrationsAssembly(typeof(LaLigaContext).Assembly.FullName)));

            #region Repositories
            services.AddTransient<IMatchesRepository, MatchesRepository>();//
            services.AddTransient<ITeamsRepository, TeamsRepository>();//
            
            //services.AddTransient<ICustomerRepository, CustomerRepository>();//

            #endregion

            return services;
        }
    }
}
