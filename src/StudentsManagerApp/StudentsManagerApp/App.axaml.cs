using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentsManager.Application.DepedencyInjection;
using StudentsManager.Infrastructure.DependencyInjection;
using StudentsManagerApp.DependencyInjection;
using StudentsManagerApp.ViewModels;
using StudentsManagerApp.Views;
using System;
using System.IO;

namespace StudentsManagerApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        string[] commandLineArgs = Environment.GetCommandLineArgs();

        IConfiguration config = BuildConfiguration(commandLineArgs);
        IServiceProvider provider = BuildServiceProvider(config);

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

    private IConfiguration BuildConfiguration(string[] commandLineArgs)
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddCommandLine(commandLineArgs)
            .AddEnvironmentVariables()
            .Build();
    }

    private IServiceProvider BuildServiceProvider(IConfiguration config)
    {
        return new ServiceCollection()
            .AddApplication(config)
            .AddInfrastructure(config)
            .AddServices(config)
            .AddUI(config)
            .BuildServiceProvider();
    }
}
