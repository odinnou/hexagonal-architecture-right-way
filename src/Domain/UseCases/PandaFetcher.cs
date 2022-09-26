using Domain.Exceptions;
using Domain.Models;
using Domain.Ports;

namespace Domain.UseCases
{
    public class PandaFetcher : IPandaFetcher // Notice the presence of this interface.
    {
        // No IPandaPort implementation in the Domain layer? It's normal.
        private readonly IPandaPort _pandaPort;

        public PandaFetcher(IPandaPort pandaPort)
        {
            _pandaPort = pandaPort;
        }

        public async Task<Panda> Execute(Guid pandaId)
        {
            Panda? panda = await _pandaPort.GetById(pandaId);

            if (panda == null)
            {
                throw new PandaNotFoundException(pandaId);
            }

            return panda;
        }
    }
}
