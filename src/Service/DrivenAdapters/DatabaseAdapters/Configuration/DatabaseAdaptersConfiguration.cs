using Domain.Ports.Driven;
using Microsoft.EntityFrameworkCore;
using Service.DrivenAdapters.DatabaseAdapters.Migrations;

namespace Service.DrivenAdapters.DatabaseAdapters.Configuration;

public static class DatabaseAdaptersConfiguration
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, string databaseConnection)
    {
        services.AddDbContext<PandaContext>(options => options.UseLazyLoadingProxies().UseNpgsql(databaseConnection).UseSnakeCaseNamingConvention());
        services.AddHostedService<MigratorHostedService>();

        services.AddTransient<IPandaPersistencePort, PandaPersistenceAdapter>();

        return services;
    }
}
