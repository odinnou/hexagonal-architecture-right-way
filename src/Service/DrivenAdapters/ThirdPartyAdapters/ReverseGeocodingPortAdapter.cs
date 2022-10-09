using Domain.Ports.Driven;
using RestSharp;
using Service.DrivenAdapters.ThirdPartyAdapters.Dtos;

namespace Service.DrivenAdapters.ThirdPartyAdapters;

public class ReverseGeocodingPortAdapter : IReverseGeocodingPort, IDisposable
{
    private readonly RestClient _client;

    public ReverseGeocodingPortAdapter(string reverseGeocodingBaseUrl)
    {
        _client = new RestClient(new RestClientOptions(reverseGeocodingBaseUrl));
    }

    public async Task<string?> GetAddressForCoordinates(decimal latitude, decimal longitude)
    {
        // GET /reverse-geocoding?latitude={latitude}&longitude={longitude}, using RestSharp
        AddressDto? addressDto = await _client.GetJsonAsync<AddressDto>("reverse-geocoding", new { latitude, longitude });

        return addressDto!.Address;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _client?.Dispose();
        }
    }
}
