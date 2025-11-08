using Agropet.Application.Response;
using Agropet.Application.UseCases.Usuario.Commands;
using Agropet.Application.UseCases.Usuario.Responses;
using Agropet.Domain.Entities;
using Agropet.Domain.Interfaces;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
    private readonly IPasswordHasher<Domain.Entities.Usuario> _passwordHasher;

    public CadastrarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IPasswordHasher<Domain.Entities.Usuario> passwordHasher)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

    public async Task<Resposta> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = request.Adapt<Domain.Entities.Usuario>();
        usuario.DefinirSenha(request.Senha, _passwordHasher);
        _usuarioRepository.Criar(usuario);
        await _unitOfWork.Commit(cancellationToken);
        var usuarioResponse = usuario.Adapt<UsuarioResponse>();

        return new Resposta((int)HttpStatusCode.Created, usuarioResponse);
    }
}

public sealed class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, Resposta>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AtualizarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Resposta> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = _usuarioRepository.Obter(request.Id);
        usuario.AtualizarNome(request.Nome)
            .AtualizarCPF(request.CPF);

        _usuarioRepository.Atualizar(usuario);
        await _unitOfWork.Commit(cancellationToken);
        var usuarioResponse = usuario.Adapt<UsuarioResponse>();

        return new Resposta((int)HttpStatusCode.Created, usuarioResponse);
    }
}

public sealed class DeletarUsuarioCommandHandler : IRequestHandler<DeletarUsuarioCommand, Resposta>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletarUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
    {
        _usuarioRepository = usuarioRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Resposta> Handle(DeletarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var sucesso = _usuarioRepository.Deletar(request.id);
        if (sucesso == 0)
            return new Resposta((int)HttpStatusCode.UnprocessableContent, false, "Usuario não encontrado");

        await _unitOfWork.Commit(cancellationToken);

        return new Resposta((int)HttpStatusCode.NoContent);
    }
}