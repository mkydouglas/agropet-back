using Agropet.Application.Auth.Commands;
using Agropet.Application.Common.Response;
using Agropet.Application.Common.Services;
using Agropet.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Security.Claims;

namespace Agropet.Application.Auth.Handlers;

public sealed class AuthCommandHandler : IRequestHandler<AuthCommand, Resposta>
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPasswordHasher<Domain.Entities.Usuario> _passwordHasher;

    public AuthCommandHandler(IUsuarioRepository usuarioRepo, IPasswordHasher<Domain.Entities.Usuario> passwordHasher)
    {
        _usuarioRepository = usuarioRepo;
        _passwordHasher = passwordHasher;
    }

    public Task<Resposta> Handle(AuthCommand request, CancellationToken cancellationToken)
    {
        var user = _usuarioRepository.Obter(request.CPF);
        if (user == null)
            return null!;

        var verifyResult = _passwordHasher.VerifyHashedPassword(user, user.SenhaHash, request.Senha);
        if (verifyResult == PasswordVerificationResult.Failed)
            return Task.FromResult(new Resposta((int)HttpStatusCode.BadRequest, false, "Falha na autenticação. Verifique seu login e senha."));

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };
        var token = new JWTService().CreateToken(claims);
        return Task.FromResult(new Resposta((int)HttpStatusCode.OK, data: token));
    }
}
