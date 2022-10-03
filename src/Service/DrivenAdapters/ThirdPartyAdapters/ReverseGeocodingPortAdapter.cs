using Domain.Ports.Driven;

namespace Service.DrivenAdapters.ThirdPartyAdapters;

public class ReverseGeocodingPortAdapter : IReverseGeocodingPort
{
    public Task<string?> GetAddressForCoordinates(decimal latitude, decimal longitude)
    {
        throw new NotImplementedException();
    }
}
