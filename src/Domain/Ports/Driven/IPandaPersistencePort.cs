using Domain.Models;

namespace Domain.Ports.Driven;

public interface IPandaPersistencePort
{
    Task<Panda?> GetById(Guid pandaId);
}
