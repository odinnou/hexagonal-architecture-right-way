using Domain.Exceptions;
using Domain.Models;
using Domain.Ports.Driven;
using Domain.Ports.Driving;

namespace Domain.UseCases;

public class PandaFetcher : IPandaFetcher // Notice the presence of this interface.
{
    // No IPandaPersistencePort or IReverseGeocodingPort implementation in the Domain layer? It's normal.
    private readonly IPandaPersistencePort _pandaPersistencePort;
    private readonly IReverseGeocodingPort _reverseGeocodingPort;

    public PandaFetcher(IPandaPersistencePort pandaPersistencePort, IReverseGeocodingPort reverseGeocodingPort)
    {
        _pandaPersistencePort = pandaPersistencePort;
        _reverseGeocodingPort = reverseGeocodingPort;
    }

    public async Task<Panda> Execute(Guid pandaId)
    {
        Panda? panda = await _pandaPersistencePort.GetById(pandaId);

        if (panda == null)
        {
            throw new PandaNotFoundException(pandaId);
        }

        // You could test with latitude = "47.247703075231634" and longitude = "1.3531078346932406"
        panda.LastKnownAddress = await _reverseGeocodingPort.GetAddressForCoordinates(panda.Latitude, panda.Longitude);

        return panda;
    }
}
