using Agropet.Application.Response;
using Agropet.Application.UseCases.Usuario.Commands;
using Agropet.Application.UseCases.Usuario.Responses;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Mapster;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Usuario.Handlers;

public sealed class CadastrarUsuarioCommandHandler : IRequestHandler<CadastrarUsuarioCommand, Resposta>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CadastrarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Resposta> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = request.Adapt<Domain.Entities.Usuario>();
        _usuarioRepository.Criar(usuario);
        await _unitOfWork.Commit(cancellationToken);
        var usuarioResponse = usuario.Adapt<CadastrarUsuarioResponse>();

        return new Resposta((int)HttpStatusCode.Created, usuarioResponse);
    }
}
