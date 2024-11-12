using Blazored.LocalStorage;
using Esportify.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<UserService>(client => { client.BaseAddress = new Uri("https://localhost:7102/"); });
builder.Services.AddHttpClient<EventService>(client => { client.BaseAddress = new Uri("https://localhost:7102/"); });
builder.Services.AddHttpClient<EventStatusService>(client => { client.BaseAddress = new Uri("https://localhost:7102/"); });
builder.Services.AddHttpClient<EventImageService>(client => { client.BaseAddress = new Uri("https://localhost:7102/"); });
builder.Services.AddHttpClient<EventUserService>(client => { client.BaseAddress = new Uri("https://localhost:7102/"); });
builder.Services.AddHttpClient<RoleService>(client => { client.BaseAddress = new Uri("https://localhost:7102/"); });
builder.Services.AddHttpClient<AuthService>(client => { client.BaseAddress = new Uri("https://localhost:7102/"); });

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventStatusService, EventStatusService>();
builder.Services.AddScoped<IEventImageService, EventImageService>();
builder.Services.AddScoped<IEventUserService, EventUserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();