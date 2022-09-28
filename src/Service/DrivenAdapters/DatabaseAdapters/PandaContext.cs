using Microsoft.EntityFrameworkCore;
using Service.DrivenAdapters.DatabaseAdapters.Entities.Mappings;

#nullable disable warnings
namespace Service.DrivenAdapters.DatabaseAdapters;

public class PandaContext : DbContext
{
    public PandaContext(DbContextOptions<PandaContext> options) : base(options)
    {
    }

    public DbSet<PandaEntity> Pandas { get; set; }
}
