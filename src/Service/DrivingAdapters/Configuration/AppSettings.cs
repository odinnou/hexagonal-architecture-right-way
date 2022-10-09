#nullable disable warnings

namespace Service.DrivingAdapters.Configuration;

public class AppSettings
{
    public string DatabaseConnection { get; set; }
    public string ReverseGeocodingBaseUrl { get; set; }
}