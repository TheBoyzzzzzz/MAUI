using System.Reflection;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StaffManager.Application.Abstractions;
using StaffManager.Application.Services;
using StaffManager.Domain.Abstractions;
using StaffManager.Persistence.UnitOfWork;
using StaffManager.UI.ViewModels;

namespace StaffManager.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        string settingsStream = "StaffManager.UI.appsettings.json";
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream(settingsStream);
        builder.Configuration.AddJsonStream(stream);

#if DEBUG
        builder.Logging.AddDebug();
#endif


        SetupServices(builder.Services);
        SetupViewModels(builder.Services);
        SetupViews(builder.Services);
        return builder.Build();
    }

    private static void SetupServices(IServiceCollection services)
    {
        services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
        services.AddSingleton<IPositionService, PositionService>();
        services.AddSingleton<IPositionResponsibilityService, PositionResponsibilityService>();
    }

    private static void SetupViewModels(IServiceCollection services)
    {
        services.AddSingleton<PositionsViewModel>();
    }
    private static void SetupViews(IServiceCollection services)
    {
        services.AddTransient<Pages.Positions>();
    }
}
