using Agropet.Application.Common.Mappings;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Agropet.Application;

public static class ServiceExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        var config = TypeAdapterConfig.GlobalSettings;
        MappingConfig.RegisterMappings(config);
        services.AddSingleton(config);

        services.AddScoped<IPasswordHasher<Domain.Entities.Usuario>, PasswordHasher<Domain.Entities.Usuario>>();
    }
}
