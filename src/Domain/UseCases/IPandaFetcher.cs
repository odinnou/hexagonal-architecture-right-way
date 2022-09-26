using Domain.Models;

namespace Domain.UseCases
{
    public interface IPandaFetcher
    {
        Task<Panda> Execute(Guid pandaId);
    }
}
