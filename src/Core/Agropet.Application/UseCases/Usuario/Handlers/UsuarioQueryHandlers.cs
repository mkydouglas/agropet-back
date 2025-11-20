using Agropet.Application.Response;
using Agropet.Application.UseCases.Usuario.Queries;
using Agropet.Application.UseCases.Usuario.Responses;
using Agropet.Domain.Interfaces;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.UseCases.Usuario.Handlers;

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
        var usuario = _usuarioRepository.Listar();
        var usuarioResponse = usuario.Adapt<List<UsuarioResponse>>();
        return Task.FromResult(new Resposta((int)HttpStatusCode.OK, usuarioResponse));
    }
}
