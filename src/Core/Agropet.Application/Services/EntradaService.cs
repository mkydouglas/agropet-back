using Agropet.Application.DTOs;
using Agropet.Application.Interfaces;
using Agropet.Application.Response;
using Agropet.Domain.Entities;
using Agropet.Domain.Enums;
using Agropet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Agropet.Application.Services;

public class EntradaService// : IEntradaService
{
    private readonly IProdutoService _produtoService;
    private readonly IFornecedorService _fornecedorService;
    private readonly IMovimentacaoEstoqueService _movimentacaoEstoqueService;
    private readonly ILoteService _loteService;

    public EntradaService(
        IProdutoService produtoService,
        IFornecedorService fornecedorService,
        IMovimentacaoEstoqueService movimentacaoEstoqueService,
        ILoteService loteService)
    {
        _produtoService = produtoService;
        _fornecedorService = fornecedorService;
        _movimentacaoEstoqueService = movimentacaoEstoqueService;
        _loteService = loteService;
    }

    public Task<Resposta> CadastrarManual(EntradaDTO entrada)
    {
        //try
        //{
        //    Cadastrar(entrada);
        //    return Task.FromResult(new Resposta((int)HttpStatusCode.Created));
        //}
        //catch
        //{
        //    return Task.FromResult(new Resposta((int)HttpStatusCode.UnprocessableContent, false, "Não foi possível realizar o cadastro."));
        //}
        return Task.FromResult(new Resposta((int)HttpStatusCode.UnprocessableContent, false, "Não foi possível realizar o cadastro."));
    }

    //public Task<Resposta> CadastrarViaNF(Stream stream)
    //{
    //    NfeProc? nota = null;

    //    using (XmlReader reader = XmlReader.Create(stream))
    //    {
    //        reader.MoveToContent(); // Move para o nó raiz

    //        string namespaceXml = reader.NamespaceURI; // Captura o namespace dinamicamente

    //        // Criar serializer com o namespace correto
    //        XmlSerializer serializer = new XmlSerializer(typeof(NfeProc), namespaceXml);

    //        using (reader)
    //        {
    //            nota = (NfeProc)serializer.Deserialize(reader);
    //        }
    //    }

    //    if (nota == null)
    //        return Task.FromResult(new Resposta((int)HttpStatusCode.UnprocessableContent, false, "Nota Fiscal não processada."));

    //    //var fornecedorDTO = nota.NFe.InfNFe.Emitente.MapearParaFornecedorDTO();
    //    //var produtoDTOs = nota.NFe.InfNFe.InfoProduto.MapearParaListaProdutoDTO();

    //    var entradaDTOs = CriarEntradaDTOs(fornecedorDTO, produtoDTOs);
    //    foreach (var entrada in entradaDTOs)
    //    {
    //        try
    //        {
    //            Cadastrar(entrada);
    //        }
    //        catch (Exception)
    //        {
    //            continue;
    //        }
    //    }

    //    return Task.FromResult(new Resposta((int)HttpStatusCode.Created));
    //}

    private void Cadastrar(EntradaDTO entrada)
    {
        //if (entrada.ProdutoDTO == null || entrada.ProdutoDTO.LoteDTO == null)
        //    return;

        //var idProduto = _produtoService.Cadastrar(entrada.ProdutoDTO);
        //var idFornecedor = 0;

        //if (entrada.FornecedorDTO != null)
        //    idFornecedor = _fornecedorService.Cadastrar(entrada.FornecedorDTO);

        //var lote = (Lote)entrada.ProdutoDTO.LoteDTO;
        //lote.IdProduto = idProduto;
        //lote.IdFornecedor = idFornecedor;

        //lote = _loteService.Criar(lote);

        //_movimentacaoEstoqueService.Criar(new MovimentacaoEstoque
        //{
        //    IdProduto = idProduto,
        //    IdLote = lote.Id,
        //    Quantidade = lote.Quantidade,
        //    ETipoMovimentacaoEstoque = ETipoMovimentacaoEstoque.Entrada
        //});
    }

    //private List<EntradaDTO> CriarEntradaDTOs(FornecedorDTO fornecedorDTO, List<ProdutoDTO> produtoDTOs)
    //{
    //    List<EntradaDTO> entradas = new List<EntradaDTO>();

    //    foreach (var produto in produtoDTOs)
    //    {
    //        entradas.Add(new EntradaDTO
    //        {
    //            FornecedorDTO = fornecedorDTO,
    //            ProdutoDTO = produto
    //        });
    //    }

    //    return entradas;
    //}
}
