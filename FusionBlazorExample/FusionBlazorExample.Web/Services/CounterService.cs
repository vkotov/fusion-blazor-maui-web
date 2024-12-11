using ActualLab.Fusion;
using FusionBlazorExample.Shared.Services;

namespace FusionBlazorExample.Web.Services;

public class CounterService : ICounterService
{
    private int _counter = 0;
    
    public Task IncrementCount(CancellationToken cancellationToken = default)
    {
        _counter++;

        using (Invalidation.Begin())
        {
            _ = GetCount(CancellationToken.None);
        }

        return Task.CompletedTask;
    }

    public virtual Task<int> GetCount(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_counter);
    }
}