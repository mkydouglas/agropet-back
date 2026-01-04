using Agropet.Application.Fornecedor.Commands;
using Agropet.Application.Fornecedor.Responses;
using Agropet.Application.Lote.Commands;
using Agropet.Application.Lote.Responses;
using Agropet.Application.Produto.Commands;
using Agropet.Application.Produto.Responses;
using Agropet.Application.Usuario.Commands;
using Agropet.Application.Usuario.Responses;
using Agropet.Domain.Models;
using Mapster;

namespace Agropet.Application.Common.Mappings
{
    public static class MappingConfig
    {
        public static void RegisterMappings(TypeAdapterConfig config)
        {
            config.NewConfig<CadastrarUsuarioCommand, Domain.Entities.Usuario>();
            config.NewConfig<Domain.Entities.Usuario, UsuarioResponse>();
            config.NewConfig<AtualizarUsuarioCommand, Domain.Entities.Usuario>();
            config.NewConfig<CadastrarProdutoCommand, Domain.Entities.Produto>();
            config.NewConfig<Domain.Entities.Produto, CadastrarProdutoResponse>();
            config.NewConfig<Domain.Entities.Produto, AtualizarProdutoResponse>();
            config.NewConfig<CadastrarLoteCommand, Domain.Entities.Lote>();
            config.NewConfig<Domain.Entities.Lote, LoteResponse>();
            config.NewConfig<CadastrarFornecedorCommand, Domain.Entities.Fornecedor>();
            config.NewConfig<Domain.Entities.Fornecedor, FornecedorResponse>();
            config.NewConfig<Emitente, Domain.Entities.Fornecedor>()
                .Map(d => d.Telefone, s => s.EnderEmit.Fone);
            config.NewConfig<ProdutoXml, Domain.Entities.Produto>()
                .Map(d => d.PrecoUnitarioCompra, s => s.ValorUnidadeComercial);
            config.NewConfig<Rastro, Domain.Entities.Lote>()
                .Map(d => d.Numero, s => s.NLote)
                .Map(d => d.Quantidade, s => s.QLote)
                .Map(d => d.DataFabricacao, s => s.DFab)
                .Map(d => d.DataValidade, s => s.DVal);
            // adicione outros mapeamentos aqui
        }
    }
}