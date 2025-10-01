using Microsoft.Extensions.DependencyInjection;

namespace StudentsManager.Application.DepedencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
