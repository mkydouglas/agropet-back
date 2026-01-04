using Agropet.Application.Common.Response;
using Agropet.Application.Lote.Commands;
using Agropet.Application.Lote.Responses;
using Agropet.Domain.Interfaces;
using Mapster;
using MediatR;
using System.Net;

namespace Agropet.Application.Lote.Handlers;

public sealed class CadastrarLoteCommandHandler : IRequestHandler<CadastrarLoteCommand, Resposta>
{
    private readonly ILoteRepository _loteRepository;
    private readonly IFornecedorRepository _fornecedorRepository;
    private readonly IFornecedorLoteRepository _fornecedorLoteRepository;
    private readonly IUnitOfWork _unitOfWork;


    public CadastrarLoteCommandHandler(ILoteRepository loteRepository, IUnitOfWork unitOfWork, IFornecedorRepository fornecedorRepository, IFornecedorLoteRepository fornecedorLoteRepository)
    {
        _loteRepository = loteRepository;
        _unitOfWork = unitOfWork;
        _fornecedorRepository = fornecedorRepository;
        _fornecedorLoteRepository = fornecedorLoteRepository;
    }

    public async Task<Resposta> Handle(CadastrarLoteCommand request, CancellationToken cancellationToken)
    {
        //TODO: Rever fluxo
        var lote = request.Adapt<Domain.Entities.Lote>();
        _loteRepository.Criar(lote);

        await _unitOfWork.Commit(cancellationToken);

        var loteDto = lote.Adapt<LoteResponse>();
        return new Resposta((int)HttpStatusCode.Created, loteDto);
    }
}

public sealed class AtualizarLoteCommandHandler : IRequestHandler<AtualizarLoteCommand, Resposta>
{
    private readonly ILoteRepository _loteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AtualizarLoteCommandHandler(ILoteRepository loteRepository, IUnitOfWork unitOfWork)
    {
        _loteRepository = loteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Resposta> Handle(AtualizarLoteCommand request, CancellationToken cancellationToken)
    {
        var lote = await _loteRepository.ObterAsync(request.Id);
        if (lote == null)
            return new Resposta((int)HttpStatusCode.BadRequest);

        //TODO: Rever fluxo
        lote.Atualizar(
            request.Numero,
            request.Quantidade,
            request.UnidadeComercial,
            request.PrecoUnitarioCompra,
            request.DataFabricacao.Value,
            request.DataValidade.Value
        );

        _loteRepository.Atualizar(lote);
        await _unitOfWork.Commit(cancellationToken);

        var loteDto = lote.Adapt<LoteResponse>();
        return new Resposta((int)HttpStatusCode.OK, loteDto);
    }
}

public sealed class DeletarLoteCommandHandler : IRequestHandler<DeletarLoteCommand, Resposta>
{
    private readonly ILoteRepository _loteRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletarLoteCommandHandler(ILoteRepository loteRepository, IUnitOfWork unitOfWork)
    {
        _loteRepository = loteRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Resposta> Handle(DeletarLoteCommand request, CancellationToken cancellationToken)
    {
        var lote = await _loteRepository.ObterAsync(request.Id);
        if (lote == null)
            return new Resposta((int)HttpStatusCode.BadRequest);

        _loteRepository.Deletar(request.Id);
        await _unitOfWork.Commit(cancellationToken);

        return new Resposta((int)HttpStatusCode.OK);
    }
}