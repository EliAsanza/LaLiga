using LaLiga.Application.Services;
using LaLiga.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace LaLiga.Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            #region Services
            services.AddTransient<IMatchesService, MatchesService>();//
            services.AddTransient<ITeamsService, TeamsService>();//

            #endregion

            return services;
        }
    }
}
