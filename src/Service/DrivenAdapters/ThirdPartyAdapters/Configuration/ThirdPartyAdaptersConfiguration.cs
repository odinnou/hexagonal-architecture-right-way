using Domain.Ports.Driven;
using Service.DrivenAdapters.ThirdPartyAdapters;
using Service.DrivingAdapters.Configuration;

namespace Service.DrivenAdapters.DatabaseAdapters.Configuration;

public static class ThirdPartyAdaptersConfiguration
{
    public static IServiceCollection AddThirdParties(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddTransient<IReverseGeocodingPort, ReverseGeocodingPortAdapter>();

        return services;
    }
}
