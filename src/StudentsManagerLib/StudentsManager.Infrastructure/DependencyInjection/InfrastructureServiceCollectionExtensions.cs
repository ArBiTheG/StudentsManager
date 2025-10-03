using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentsManager.Infrastructure.DbContexts;

namespace StudentsManager.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("sqlite");

        if (connectionString is not null)
        {
            services.AddDbContextFactory<StudentsDbContext>(options => options.UseSqlite(connectionString));
        }

        return services;
    }
}
