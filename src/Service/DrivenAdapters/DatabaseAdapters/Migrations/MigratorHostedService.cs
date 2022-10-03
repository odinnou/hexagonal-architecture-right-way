using Microsoft.EntityFrameworkCore;

namespace Service.DrivenAdapters.DatabaseAdapters.Migrations;

public class MigratorHostedService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public MigratorHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using IServiceScope scope = _serviceProvider.CreateScope();
        PandaContext pandaContext = scope.ServiceProvider.GetRequiredService<PandaContext>();

        await pandaContext.Database.MigrateAsync(cancellationToken: cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
