using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace CarStore.WebAPI.Core.Middlewares;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IAuthorizationService _authorizationService;

    public AuthorizationBehavior(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var authorizationResult = await _authorizationService.AuthorizeAsync(null, request, "PolicyName");
        if (!authorizationResult.Succeeded)
        {
            throw new UnauthorizedAccessException();
        }

        return await next();
    }
}