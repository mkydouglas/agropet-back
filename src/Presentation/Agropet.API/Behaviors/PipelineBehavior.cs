using Agropet.Application;
using MediatR;
using System.Security.Claims;

namespace Agropet.API.Behaviors;

public class PipelineBehavior<TRequest, TResp> : IPipelineBehavior<TRequest, TResp>
{
    private readonly ICurrentUser _currentUser;

    public PipelineBehavior(ICurrentUser currentUser)
    {
        _currentUser = currentUser;
    }

    public async Task<TResp> Handle(TRequest request, RequestHandlerDelegate<TResp> next, CancellationToken cancellationToken)
    {
        if (request is CommandQueryBase commandQueryBase)
        {
            commandQueryBase.UserId = _currentUser.UserId;
            commandQueryBase.Email = _currentUser.Email;
        }

        return await next();
    }
}

public interface ICurrentUser
{
    int? UserId { get; }
    string? Email { get; }
}

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _context;

    public CurrentUser(IHttpContextAccessor context)
    {
        _context = context;
    }

    public int? UserId =>
        int.TryParse(
            _context.HttpContext?
                .User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
            out var id
        ) ? id : null;

    public string? Email =>
        _context.HttpContext?
            .User.FindFirst(ClaimTypes.Email)?.Value;
}

