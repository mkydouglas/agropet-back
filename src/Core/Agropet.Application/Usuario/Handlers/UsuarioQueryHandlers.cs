using Agropet.Application.Common.Response;
using Agropet.Application.Usuario.Queries;
using Agropet.Application.Usuario.Responses;
using Agropet.Domain.Interfaces;
using Mapster;
using MediatR;
using System.Net;

namespace Agropet.Application.Usuario.Handlers;

public sealed class ObterUsuarioQueryHandler : IRequestHandler<ObterUsuarioQuery, Resposta>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ObterUsuarioQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public Task<Resposta> Handle(ObterUsuarioQuery request, CancellationToken cancellationToken)
    {
        var usuario = _usuarioRepository.ObterAsync(request.id);
        var usuarioResponse = usuario.Adapt<UsuarioResponse>();
        return Task.FromResult(new Resposta((int)HttpStatusCode.OK, usuarioResponse));
    }
}

public sealed class ListarUsuarioQueryHandler : IRequestHandler<ListarUsuarioQuery, Resposta>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ListarUsuarioQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public Task<Resposta> Handle(ListarUsuarioQuery request, CancellationToken cancellationToken)
    {
        var usuario = _usuarioRepository.ListarAsync();
        var usuarioResponse = usuario.Adapt<List<UsuarioResponse>>();
        return Task.FromResult(new Resposta((int)HttpStatusCode.OK, usuarioResponse));
    }
}
