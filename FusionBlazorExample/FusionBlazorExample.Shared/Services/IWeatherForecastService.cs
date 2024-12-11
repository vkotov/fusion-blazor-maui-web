using System.Runtime.Serialization;
using ActualLab.Fusion;
using ActualLab.Fusion.Blazor;
using MemoryPack;
using MessagePack;

namespace FusionBlazorExample.Shared.Services;

public interface IWeatherForecastService : IComputeService
{
    [ComputeMethod(AutoInvalidationDelay = 10)]
    Task<WeatherForecast[]> GetForecast(CancellationToken cancellationToken = default);
}

[DataContract, MemoryPackable, MessagePackObject]
[ParameterComparer(typeof(ByValueParameterComparer))]
public sealed partial record WeatherForecast(
    [property: DataMember, Key(0)] DateTime Date,
    [property: DataMember, Key(1)] int TemperatureC,
    [property: DataMember, Key(2)] string? Summary
);
