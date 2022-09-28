using Domain.Models;

namespace Domain.Ports.Driving;

public interface IPandaFetcher
{
    Task<Panda> Execute(Guid pandaId);
}
