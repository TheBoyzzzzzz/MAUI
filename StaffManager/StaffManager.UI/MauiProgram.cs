using System.Reflection;
using CommunityToolkit.Maui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StaffManager.Application.Abstractions;
using StaffManager.Application.Services;
using StaffManager.Domain.Abstractions;
using StaffManager.Domain.Entities;
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
        SeedData(builder.Services);
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
        services.AddSingleton<MainViewModel>();
        services.AddTransient<PositionResponsibilityDetailsViewModel>();
    }

    private static void SetupViews(IServiceCollection services)
    {
        services.AddTransient<Positions>();
        services.AddTransient<PositionResponsibilityDetails>();
        services.AddTransient<MainPage>();
    }

    private static void AddDbContext(MauiAppBuilder builder)
    {
        var connStr = builder.Configuration
         .GetConnectionString("SqliteConnection");
        string dataDirectory = string.Empty;
#if ANDROID
        dataDirectory = FileSystem.AppDataDirectory + "/";
#endif
        connStr = string.Format(connStr, dataDirectory);
        var options = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(connStr).Options;
        builder.Services.AddSingleton((s) => new AppDbContext(options));
    }

    public async static Task SeedData(IServiceCollection services)
    {
        using var provider = services.BuildServiceProvider();
        var unitOfWork = provider.GetRequiredService<IUnitOfWork>();
        await unitOfWork.RemoveDatbaseAsync();
        await unitOfWork.CreateDatabaseAsync();

        var positions = new List<Position>()
        {
            new Position {Name = "SEO", Salary=1000, Id = 1},
            new Position {Name = "Manager", Salary = 500, Id = 2},
            new Position { Name = "Employee", Salary = 100, Id = 3}
        };

        foreach (var pos in positions)
        {
            await unitOfWork.PositionRepository.AddAsync(pos);
        }
        await unitOfWork.SaveAllAsync();

        Random rnd = new();
        for (int i = 0; i < 15; i++)
        {
            await unitOfWork.PositionResponsibilityRepository.AddAsync(new PositionResponsibility()
            {
                Name = $"Responsibility#{i + 1}",
                Description = $"Description#{i + 1}",
                Id = i + 1,
                Importance = rnd.Next(1, 7),
                Position = positions[rnd.Next(1, 10) % positions.Count()]
            });
        }
        await unitOfWork.SaveAllAsync();
    }
}
