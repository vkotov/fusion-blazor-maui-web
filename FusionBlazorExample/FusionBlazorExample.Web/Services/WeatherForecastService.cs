using FusionBlazorExample.Shared.Services;

namespace FusionBlazorExample.Web.Services;

public class WeatherForecastService : IWeatherForecastService
{
    public virtual async Task<WeatherForecast[]> GetForecast(CancellationToken cancellationToken = default)
    {
        // Simulate asynchronous loading to demonstrate a loading indicator
        await Task.Delay(500, cancellationToken);

        var startDate = DateTime.UtcNow.Date;
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast(Date: startDate.AddDays(index), TemperatureC: Random.Shared.Next(-20, 55), Summary: summaries[Random.Shared.Next(summaries.Length)])).ToArray();
    }
}