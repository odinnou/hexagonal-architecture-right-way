namespace Domain.Ports
{
    public interface IReverseGeocodingPort
    {
        Task<string?> GetAddressForCoordinates(decimal latitude, decimal longitude);
    }
}
