using Agropet.Application.Common.Interfaces;
using Agropet.Application.Common.Mappings;
using Agropet.Application.Common.Services;
using Agropet.Application.Compra.Services;
using Agropet.Application.Compra.Validators;
using Agropet.Application.Venda.Services;
using FluentValidation;
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

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IFornecedorService, FornecedorService>();
        services.AddScoped<IPasswordHasher<Domain.Entities.Usuario>, PasswordHasher<Domain.Entities.Usuario>>();
        services.AddScoped<IProcessadorCompra, ProcessadorCompra>();
        services.AddScoped<IProcessadorVenda, ProcessadorVenda>();
    }
}
