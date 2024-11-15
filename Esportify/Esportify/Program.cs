using Blazored.LocalStorage;
using Esportify.Components;
using Esportify.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient<UserService>(client => { client.BaseAddress = new Uri("https://esportify-api.azurewebsites.net/"); });
builder.Services.AddHttpClient<EventService>(client => { client.BaseAddress = new Uri("https://esportify-api.azurewebsites.net/"); });
builder.Services.AddHttpClient<EventStatusService>(client => { client.BaseAddress = new Uri("https://esportify-api.azurewebsites.net/"); });
builder.Services.AddHttpClient<EventImageService>(client => { client.BaseAddress = new Uri("https://esportify-api.azurewebsites.net/"); });
builder.Services.AddHttpClient<EventUserService>(client => { client.BaseAddress = new Uri("https://esportify-api.azurewebsites.net/"); });
builder.Services.AddHttpClient<RoleService>(client => { client.BaseAddress = new Uri("https://esportify-api.azurewebsites.net/"); });

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventStatusService, EventStatusService>();
builder.Services.AddScoped<IEventImageService, EventImageService>();
builder.Services.AddScoped<IEventUserService, EventUserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddBlazoredLocalStorage();

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

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Esportify.Client._Imports).Assembly);

app.Run();