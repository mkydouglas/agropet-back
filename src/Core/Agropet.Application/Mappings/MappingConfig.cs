using Mapster;
using Agropet.Domain.Entities;
using Agropet.Application.UseCases.Usuario.Commands;
using Agropet.Application.UseCases.Usuario.Responses;

namespace Agropet.Application.Mappings
{
    public static class MappingConfig
    {
        public static void RegisterMappings(TypeAdapterConfig config)
        {
            config.NewConfig<CadastrarUsuarioCommand, Usuario>();
            config.NewConfig<Usuario, CadastrarUsuarioResponse>();
            // adicione outros mapeamentos aqui
        }
    }
}