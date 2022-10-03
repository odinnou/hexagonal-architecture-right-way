using Domain.Ports.Driving;
using Domain.UseCases;

namespace Service.DrivingAdapters.Configuration;

public static class UseCaseConfiguration
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddTransient<IPandaFetcher, PandaFetcher>();

        return services;
    }
}
