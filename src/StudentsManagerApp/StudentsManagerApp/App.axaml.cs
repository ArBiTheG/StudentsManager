using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using StudentsManager.Application.DepedencyInjection;
using StudentsManager.Infrastructure.DependencyInjection;
using StudentsManagerApp.DependencyInjection;
using StudentsManagerApp.ViewModels;
using StudentsManagerApp.Views;
using System;

namespace StudentsManagerApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        IServiceCollection services = new ServiceCollection()
            .AddApplication()
            .AddInfrastructure()
            .AddServices()
            .AddUI();

        IServiceProvider provider = services.BuildServiceProvider();

        MainViewModel mainViewModel = provider.GetRequiredService<MainViewModel>();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            MainWindow mainWindow = provider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = mainViewModel;
            desktop.MainWindow = mainWindow;
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            MainView mainView = provider.GetRequiredService<MainView>();
            mainView.DataContext = mainViewModel;
            singleViewPlatform.MainView = mainView;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
