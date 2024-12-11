using ActualLab.Fusion;
using ActualLab.Fusion.Authentication;
using ActualLab.Fusion.Blazor;
using ActualLab.Fusion.Blazor.Authentication;
using FusionBlazorExample.Services;
using FusionBlazorExample.Shared.Services;
using Microsoft.Extensions.Logging;

namespace FusionBlazorExample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add device-specific services used by the FusionBlazorExample.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            var baseUri = new Uri("http://localhost:5073");

            // Fusion
            var fusion = builder.Services.AddFusion();
            fusion.Rpc.AddWebSocketClient(baseUri);
            fusion.AddBlazor();
            // Fusion services
            fusion.AddClient<ICounterService>();
            fusion.AddClient<IWeatherForecastService>();

            
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
