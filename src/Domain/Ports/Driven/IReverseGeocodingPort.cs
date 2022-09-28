namespace Domain.Ports.Driven;

public interface IReverseGeocodingPort
{
    Task<string?> GetAddressForCoordinates(decimal latitude, decimal longitude);
}
