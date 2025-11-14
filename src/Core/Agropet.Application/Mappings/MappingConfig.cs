using Mapster;
using Agropet.Domain.Entities;
using Agropet.Application.UseCases.Usuario.Commands;
using Agropet.Application.UseCases.Usuario.Responses;
using Agropet.Application.UseCases.Produto.Commands;
using Agropet.Application.UseCases.Produto.Responses;
using Agropet.Application.UseCases.Lote.Commands;
using Agropet.Application.UseCases.Lote.Responses;
using Agropet.Application.UseCases.Fornecedor.Commands;
using Agropet.Application.UseCases.Fornecedor.Responses;

namespace Agropet.Application.Mappings
{
    public static class MappingConfig
    {
        public static void RegisterMappings(TypeAdapterConfig config)
        {
            config.NewConfig<CadastrarUsuarioCommand, Usuario>();
            config.NewConfig<Usuario, UsuarioResponse>();
            config.NewConfig<AtualizarUsuarioCommand, Usuario>();
            config.NewConfig<CadastrarProdutoCommand, Produto>();
            config.NewConfig<Produto, CadastrarProdutoResponse>();
            config.NewConfig<Produto, AtualizarProdutoResponse>();
            config.NewConfig<CadastrarLoteCommand, Lote>();
            config.NewConfig<Lote, LoteResponse>();
            config.NewConfig<CadastrarFornecedorCommand, Fornecedor>();
            config.NewConfig<Fornecedor, FornecedorResponse>();
            // adicione outros mapeamentos aqui
        }
    }
}