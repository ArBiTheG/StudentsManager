using Microsoft.Extensions.DependencyInjection;
using StudentsManagerApp.ViewModels;
using StudentsManagerApp.Views;

namespace StudentsManagerApp.DependencyInjection;

public static class UIServiceCollectionExtensions
{
    public static IServiceCollection AddUI(this IServiceCollection services)
    {
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainView>();
        services.AddSingleton<MainWindow>();

        return services;
    }
}
