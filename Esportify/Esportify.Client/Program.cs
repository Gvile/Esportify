using Esportify.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<EventService>(client => { client.BaseAddress = new Uri("https://localhost:7102/"); });

builder.Services.AddScoped<IEventService, EventService>();

await builder.Build().RunAsync();