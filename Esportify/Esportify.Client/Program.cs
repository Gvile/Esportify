using Blazored.LocalStorage;
using Esportify.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<UserService>(client => { client.BaseAddress = new Uri("https://esportify-api.azurewebsites.net/"); });
builder.Services.AddHttpClient<EventService>(client => { client.BaseAddress = new Uri("https://esportify-api.azurewebsites.net/"); });
builder.Services.AddHttpClient<EventStatusService>(client => { client.BaseAddress = new Uri("https://esportify-api.azurewebsites.net/"); });
builder.Services.AddHttpClient<EventImageService>(client => { client.BaseAddress = new Uri("https://esportify-api.azurewebsites.net/"); });
builder.Services.AddHttpClient<EventUserService>(client => { client.BaseAddress = new Uri("https://esportify-api.azurewebsites.net/"); });
builder.Services.AddHttpClient<RoleService>(client => { client.BaseAddress = new Uri("https://esportify-api.azurewebsites.net/"); });
builder.Services.AddHttpClient<AuthService>(client => { client.BaseAddress = new Uri("https://esportify-api.azurewebsites.net/"); });

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventStatusService, EventStatusService>();
builder.Services.AddScoped<IEventImageService, EventImageService>();
builder.Services.AddScoped<IEventUserService, EventUserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();