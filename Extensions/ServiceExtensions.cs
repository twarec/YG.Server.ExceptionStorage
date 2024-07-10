using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using YG.Server.ExceptionStorage.DataBase;
using YG.Server.ExceptionStorage.Services;
using YG.Server.ExceptionStorage.Services.Runtime;

namespace YG.Server.ExceptionStorage.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddExceptionsStorage(this IServiceCollection services, IConfiguration configuration)
    {
        Configurate.Singleton = configuration.GetSection("Modules:YG.Server.ExceptionStorage").Get<Configurate>()?? new Configurate();

        services.AddDbContext<GeneralContext>(_ =>
        {
            _.UseNpgsql(Configurate.Singleton.DataBaseConnection);
        });

        services
            .AddScoped<IRootService, RootService>()
            .AddScoped<IBodyService, BodyService>();

        return services;
    }

    public static SwaggerGenOptions AddExceptionsStorage(this SwaggerGenOptions options)
    {
        options.SwaggerDoc(name: "ExceptionStorage", new OpenApiInfo { Title = "ExceptionStorage", Version = "ExceptionStorage" });
        return options;
    }

    public static SwaggerUIOptions AddExceptionsStorage(this SwaggerUIOptions options)
    {
        options.SwaggerEndpoint(url: $"./swagger/ExceptionStorage/swagger.json", name: "ExceptionStorage");
        return options;
    }
    public static IEndpointRouteBuilder UseExceptionsStorage(this IEndpointRouteBuilder builder)
    {
        return builder;
    }
}
