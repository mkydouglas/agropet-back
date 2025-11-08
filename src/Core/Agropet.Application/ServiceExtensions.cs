using Agropet.Application.Mappings;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();
    }
}
