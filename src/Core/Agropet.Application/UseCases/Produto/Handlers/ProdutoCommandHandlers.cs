using Agropet.Application.Response;
using Agropet.Application.UseCases.Produto.Commands;
using Agropet.Application.UseCases.Produto.Responses;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Produto.Handlers;

public sealed class CadastrarProdutoCommandHandler : IRequestHandler<CadastrarProdutoCommand, Resposta>
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CadastrarProdutoCommandHandler(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
    {
        _produtoRepository = produtoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Resposta> Handle(CadastrarProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = request.Adapt<Domain.Entities.Produto>();
        _produtoRepository.Criar(produto);
        await _unitOfWork.Commit(cancellationToken);
        var produtoResponse = produto.Adapt<CadastrarProdutoResponse>();

        return new Resposta((int)HttpStatusCode.Created, produtoResponse);
    }
}

public sealed class AtualizarProdutoCommandHandler : IRequestHandler<AtualizarProdutoCommand, Resposta>
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AtualizarProdutoCommandHandler(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
    {
        _produtoRepository = produtoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Resposta> Handle(AtualizarProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = _produtoRepository.Obter(request.Id);
        if (produto == null)
            return new Resposta((int)HttpStatusCode.BadRequest);

        produto.AtualizarNome(request.Nome);
        produto.AtualizarCodigo(request.Codigo);
        produto.AtualizarCodigoBarras(request.CodigoBarras);
        produto.AtualizarMargem(request.Margem);

        _produtoRepository.Atualizar(produto);
        await _unitOfWork.Commit(cancellationToken);
        var produtoResponse = produto.Adapt<AtualizarProdutoResponse>();

        return new Resposta((int)HttpStatusCode.OK, produtoResponse);
    }
}

public sealed class DeletarProdutoCommandHandler : IRequestHandler<DeletarProdutoCommand, Resposta>
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletarProdutoCommandHandler(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
    {
        _produtoRepository = produtoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Resposta> Handle(DeletarProdutoCommand request, CancellationToken cancellationToken)
    {
        var produto = _produtoRepository.Obter(request.Id);
        if (produto == null)
            return new Resposta((int)HttpStatusCode.BadRequest);

        _produtoRepository.Deletar(request.Id);
        await _unitOfWork.Commit(cancellationToken);

        return new Resposta((int)HttpStatusCode.OK);
    }
}
