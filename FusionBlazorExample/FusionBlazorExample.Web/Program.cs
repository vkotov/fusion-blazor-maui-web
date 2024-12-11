using ActualLab.Fusion;
using ActualLab.Fusion.Authentication;
using ActualLab.Fusion.Blazor;
using ActualLab.Fusion.Blazor.Authentication;
using ActualLab.Fusion.EntityFramework;
using ActualLab.Fusion.Extensions;
using ActualLab.Fusion.Server;
using ActualLab.Rpc;
using ActualLab.Rpc.Server;
using FusionBlazorExample.Shared.Services;
using FusionBlazorExample.Web.Components;
using FusionBlazorExample.Web.Data;
using FusionBlazorExample.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContextServices<AppDbContext>(db =>
{
    db.Services.AddTransientDbContextFactory<AppDbContext>(optionsBuilder =>
    {
        optionsBuilder.UseSqlite("Data Source=fusion-blazor-example.db");
    });
});


// Fusion
var fusion = services.AddFusion(RpcServiceMode.Server);
fusion.AddWebServer();
fusion.AddBlazor();

fusion.AddService<ICounterService, CounterService>();
fusion.AddService<IWeatherForecastService, WeatherForecastService>();

// Add device-specific services used by the FusionBlazorExample.Shared project
services.AddSingleton<IFormFactor, FormFactor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseWebSockets(new WebSocketOptions()
{
    KeepAliveInterval = TimeSpan.FromSeconds(30),
});


app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(FusionBlazorExample.Shared._Imports).Assembly,
        typeof(FusionBlazorExample.Web.Client._Imports).Assembly);

app.MapRpcWebSocketServer();

app.Run();
