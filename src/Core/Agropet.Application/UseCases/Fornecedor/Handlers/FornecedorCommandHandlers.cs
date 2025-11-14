using Agropet.Application.DTOs;
using Agropet.Application.Response;
using Agropet.Application.UseCases.Fornecedor.Commands;
using Agropet.Application.UseCases.Fornecedor.Responses;
using Agropet.Domain.Interfaces;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Fornecedor.Handlers;

public sealed class CadastrarFornecedorCommandHandler : IRequestHandler<CadastrarFornecedorCommand, Resposta>
{
    private readonly IFornecedorRepository _fornecedorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CadastrarFornecedorCommandHandler(IFornecedorRepository fornecedorRepository, IUnitOfWork unitOfWork)
    {
        _fornecedorRepository = fornecedorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Resposta> Handle(CadastrarFornecedorCommand request, CancellationToken cancellationToken)
    {
        var fornecedor = request.Adapt<Domain.Entities.Fornecedor>();
        _fornecedorRepository.Criar(fornecedor);
        await _unitOfWork.Commit(cancellationToken);
        var fornecedorDto = fornecedor.Adapt<FornecedorResponse>();
        return new Resposta((int)HttpStatusCode.Created, fornecedorDto);
    }
}

public sealed class AtualizarFornecedorCommandHandler : IRequestHandler<AtualizarFornecedorCommand, Resposta>
{
    private readonly IFornecedorRepository _fornecedorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AtualizarFornecedorCommandHandler(IFornecedorRepository fornecedorRepository, IUnitOfWork unitOfWork)
    {
        _fornecedorRepository = fornecedorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Resposta> Handle(AtualizarFornecedorCommand request, CancellationToken cancellationToken)
    {
        var fornecedor = _fornecedorRepository.Obter(request.Id);
        if (fornecedor == null)
            return new Resposta((int)HttpStatusCode.BadRequest);

        fornecedor.Atualizar(request.CNPJ, request.RazaoSocial, request.NomeFantasia, request.Telefone);

        _fornecedorRepository.Atualizar(fornecedor);
        await _unitOfWork.Commit(cancellationToken);

        var fornecedorDto = fornecedor.Adapt<FornecedorResponse>();
        return new Resposta((int)HttpStatusCode.OK, fornecedorDto);
    }
}

public sealed class DeletarFornecedorCommandHandler : IRequestHandler<DeletarFornecedorCommand, Resposta>
{
    private readonly IFornecedorRepository _fornecedorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletarFornecedorCommandHandler(IFornecedorRepository fornecedorRepository, IUnitOfWork unitOfWork)
    {
        _fornecedorRepository = fornecedorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Resposta> Handle(DeletarFornecedorCommand request, CancellationToken cancellationToken)
    {
        var fornecedor = _fornecedorRepository.Obter(request.Id);
        if (fornecedor == null)
            return new Resposta((int)HttpStatusCode.BadRequest);

        _fornecedorRepository.Deletar(request.Id);
        await _unitOfWork.Commit(cancellationToken);

        return new Resposta((int)HttpStatusCode.OK);
    }
}