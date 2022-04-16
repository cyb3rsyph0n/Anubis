using Anubis.Helpers.Configurations;
using Anubis.Helpers.Interfaces.DependencyInjection;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder();

var configuration = Configuration.LoadConfiguration();
builder.Configuration.AddConfiguration(configuration);

// Add services to the container.
builder.Services.AddFastEndpoints();
builder.Services.AddAuthenticationJWTBearer(builder.Configuration["JwtSigningKey"]);
builder.Services.AddSwaggerDoc(tagIndex: 0, shortSchemaNames: true, addJWTBearerAuth: true);
builder.Services.AddHealthChecks();
builder.Services.AddMemoryCache();

builder.Services.Scan(
    scan => scan.FromAssemblyOf<IAssemblyMarker>()
        .AddClasses(c => c.AssignableTo<ITransientInjection>())
        .AsSelfWithInterfaces()
        .WithLifetime(ServiceLifetime.Transient)
        .AddClasses(c => c.AssignableTo<IScopedInjection>())
        .AsSelfWithInterfaces()
        .WithLifetime(ServiceLifetime.Scoped)
        .AddClasses(c => c.AssignableTo<ISingletonInjection>())
        .AsSelfWithInterfaces()
        .WithLifetime(ServiceLifetime.Singleton)
);

builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton(configuration);

var app = builder.Build();

// Setup app
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(
    o =>
    {
        o.ConfigureDefaults();
        o.DocExpansion = "list";
    }
);
app.Run();