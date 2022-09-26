using Domain.Models;

namespace Domain.Ports
{
    public interface IPandaPort
    {
        Task<Panda?> GetById(Guid pandaId);
    }
}
