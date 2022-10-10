using Domain.Ports.Driven;
using Service.DrivenAdapters.ThirdPartyAdapters;

namespace Service.DrivenAdapters.DatabaseAdapters.Configuration;

public static class ThirdPartyAdaptersConfiguration
{
    public static IServiceCollection AddThirdParties(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddSingleton<IReverseGeocodingPort>(new ReverseGeocodingAdapter(appSettings.ReverseGeocodingBaseUrl));

        return services;
    }
}
