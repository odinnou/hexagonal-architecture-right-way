using Domain.Ports.Driven;
using RestSharp;
using Service.DrivenAdapters.ThirdPartyAdapters.Dtos;
using System.Globalization;

namespace Service.DrivenAdapters.ThirdPartyAdapters;

public class ReverseGeocodingAdapter : IReverseGeocodingPort, IDisposable
{
    private readonly RestClient _client;

    public ReverseGeocodingAdapter(string reverseGeocodingBaseUrl)
    {
        _client = new RestClient(new RestClientOptions(reverseGeocodingBaseUrl) { ThrowOnAnyError = true });
    }

    public async Task<string?> GetAddressForCoordinates(decimal latitude, decimal longitude)
    {
        NumberFormatInfo forceDotAsDecimalSeparator = new() { NumberDecimalSeparator = "." };

        RestRequest request = new RestRequest("reverse-geocoding")
         .AddParameter("latitude", latitude.ToString(forceDotAsDecimalSeparator))
         .AddParameter("longitude", longitude.ToString(forceDotAsDecimalSeparator))
         ;

        // GET /reverse-geocoding?latitude={latitude}&longitude={longitude}, using RestSharp
        RestResponse<AddressDto> response = await _client.ExecuteGetAsync<AddressDto>(request);

        if (!response.IsSuccessStatusCode || response.ErrorException is not null)
        {
            return null;
        }

        return response.Data!.Address;
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
