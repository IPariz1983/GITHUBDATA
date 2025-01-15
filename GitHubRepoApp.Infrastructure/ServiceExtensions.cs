using GitHubRepoApp.Domain.Interfaces;
using GitHubRepoApp.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GitHubRepoApp.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Register infrastructure services here (repositories, etc.)
            services.AddScoped<IRepositoryUser, RepositoryUser>(); // Example

            return services;
        }
    }
}
