using ActualLab.Fusion;
using ActualLab.Fusion.Authentication;
using ActualLab.Fusion.Blazor;
using ActualLab.Fusion.Blazor.Authentication;
using FusionBlazorExample.Shared.Services;
using FusionBlazorExample.Web.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the FusionBlazorExample.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

var baseUri = "http://localhost:5073";
//var baseUri = "https://localhost:7026";

// Fusion
var fusion = builder.Services.AddFusion();
fusion.Rpc.AddWebSocketClient(baseUri);
fusion.AddBlazor();
//Fusion services
fusion.AddClient<ICounterService>();
fusion.AddClient<IWeatherForecastService>();

await builder.Build().RunAsync();
