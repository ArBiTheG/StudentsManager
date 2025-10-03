using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentsManagerApp.ViewModels;
using StudentsManagerApp.Views;

namespace StudentsManagerApp.DependencyInjection;

public static class UIServiceCollectionExtensions
{
    public static IServiceCollection AddUI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainView>();
        services.AddSingleton<MainWindow>();

        return services;
    }
}
