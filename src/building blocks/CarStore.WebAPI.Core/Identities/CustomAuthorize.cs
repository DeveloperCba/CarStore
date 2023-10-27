using System.Security.Claims;
using CarStore.Core.DomainObjects.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarStore.WebAPI.Core.Identities;

public class CustomAuthorization
{
    public static bool ValidateClaimsUser(HttpContext context, string claimName, string claimValue)
    {
        return context.User.Identity != null &&
               context.User.Identity.IsAuthenticated &&
               context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
    }

    public static bool ValidateRoleUser(HttpContext context, string role)
    {
        return context.User.Identity != null &&
               context.User.Identity.IsAuthenticated &&
               context.User.IsInRole(role);
    }
}

public class ClaimsAuthorizeAttribute : TypeFilterAttribute
{
    public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
    {
        Arguments = new object[] { new Claim(claimName, claimValue) };
    }
}


public class RequisitoClaimFilter : IAuthorizationFilter
{
    private readonly Claim _claim;

    public RequisitoClaimFilter(Claim claim) => _claim = claim;

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.HttpContext.User.Identity != null && !context.HttpContext.User.Identity.IsAuthenticated)
        {
            throw new UnauthorizedException(string.Empty);
        }

        if (!CustomAuthorization.ValidateClaimsUser(context.HttpContext, _claim.Type, _claim.Value))
        {
            throw new ForbiddenException(string.Empty);
        }
    }
}