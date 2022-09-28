using Microsoft.EntityFrameworkCore;
using Service.Configuration;
using Service.Core.Ports;
using Service.DrivenAdapters.DatabaseAdapters.Migrations;

namespace Service.DrivenAdapters.DatabaseAdapters.Configuration
{
    public static class DatabaseAdaptersConfiguration
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddDbContext<AlertingContext>(options => options.UseLazyLoadingProxies().UseNpgsql(appSettings.DbConnection).UseSnakeCaseNamingConvention());
            services.AddHostedService<MigratorHostedService>();

            services.AddTransient<IRulePort, RuleDatabaseAdapter>();

            return services;
        }
    }
}
