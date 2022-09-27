using Domain.Exceptions;
using Domain.Models;
using Domain.Ports;

namespace Domain.UseCases
{
    public class PandaFetcher : IPandaFetcher // Notice the presence of this interface.
    {
        // No IPandaPort or IReverseGeocodingPort implementation in the Domain layer? It's normal.
        private readonly IPandaPort _pandaPort;
        private readonly IReverseGeocodingPort _reverseGeocodingPort;

        public PandaFetcher(IPandaPort pandaPort, IReverseGeocodingPort reverseGeocodingPort)
        {
            _pandaPort = pandaPort;
            _reverseGeocodingPort = reverseGeocodingPort;
        }

        public async Task<Panda> Execute(Guid pandaId)
        {
            Panda? panda = await _pandaPort.GetById(pandaId);

            if (panda == null)
            {
                throw new PandaNotFoundException(pandaId);
            }

            panda.LastKnownAddress = await _reverseGeocodingPort.GetAddressForCoordinates(panda.Latitude, panda.Longitude);

            return panda;
        }
    }
}
