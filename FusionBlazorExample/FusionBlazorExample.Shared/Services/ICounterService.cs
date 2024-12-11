using ActualLab.Fusion;

namespace FusionBlazorExample.Shared.Services;

public interface ICounterService : IComputeService
{
    Task IncrementCount(CancellationToken cancellationToken = default);
    
    [ComputeMethod]
    Task<int> GetCount(CancellationToken cancellationToken = default);
}