using System.Reflection;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StaffManager.Application.Abstractions;
using StaffManager.Application.Services;
using StaffManager.Domain.Abstractions;
using StaffManager.Persistence.Data;
using StaffManager.Persistence.UnitOfWork;
using StaffManager.UI.Pages;
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
        AddDbContext(builder);
        
        return builder.Build();
    }

    private static void SetupServices(IServiceCollection services)
    {
        services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
        services.AddSingleton<IPositionService, PositionService>();
        services.AddSingleton<IPositionResponsibilityService, PositionResponsibilityService>();
    }

    private static void SetupViewModels(IServiceCollection services)
    {
        services.AddSingleton<PositionsViewModel>();
        services.AddSingleton<AddPositionViewModel>();
        services.AddSingleton<AddPositionResponsibilityViewModel>();
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<PositionResponsibilityDetailsViewModel>();
        services.AddSingleton<PositionStorage>();
    }

    private static void SetupViews(IServiceCollection services)
    {
        services.AddSingleton<Positions>();
        services.AddSingleton<AddPositionPage>();
        services.AddSingleton<AddPositionResponsibilityPage>();
        services.AddSingleton<PositionResponsibilityDetails>();
        services.AddSingleton<MainPage>();
    }

    private static void AddDbContext(MauiAppBuilder builder)
    {
        var connStr = builder.Configuration
         .GetConnectionString("SqliteConnection");
        string dataDirectory = string.Empty;
#if ANDROID
        dataDirectory = FileSystem.AppDataDirectory + "/";
#else
        dataDirectory = AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar;
#endif
        connStr = string.Format(connStr, dataDirectory);
        var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(connStr).Options;
        
        builder.Services.AddSingleton((s) => new AppDbContext(options));
        
    }
}
