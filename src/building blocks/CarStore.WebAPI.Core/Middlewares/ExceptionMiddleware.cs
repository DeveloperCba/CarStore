using CarStore.Core.Datas.Interfaces;
using CarStore.Core.DomainObjects;
using CarStore.Core.DomainObjects.Exceptions;
using CarStore.WebAPI.Core.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace CarStore.WebAPI.Core.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger
    )
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(
        HttpContext context,ILogErrorRepository logErrorRepository
    )
    {
        try
        {
            await _next(context);

            if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                throw new UnauthorizedException(string.Empty);

            if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
                throw new ForbiddenException(string.Empty);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            var statusCode = (int)HttpStatusCode.InternalServerError;

            var result = string.Empty;
            var errors = new List<string>();
            switch (ex)
            {
                case DomainException:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;
                case NotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    errors.Add(ex.Message);
                    break;
                case FluentValidation.ValidationException validationException:
                    statusCode = (int)HttpStatusCode.UnprocessableEntity;
                    errors.AddRange(validationException.Errors.Select(x => x.ErrorMessage));
                    break;
                case BadRequestException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    errors.Add("Not found");
                    break;
                case UnprocessableException:
                    statusCode = (int)HttpStatusCode.UnprocessableEntity;
                    errors.Add(ex.Message);
                    break;
                case ForbiddenException:
                    statusCode = (int)HttpStatusCode.Forbidden;
                    errors.Add("Without Permission to access the system, contact support!");
                    break;
                case UnauthorizedException:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    errors.Add("Not Authorized, contact support!");
                    break;

                case InternalServerErrorException:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    errors.Add("An internal error has occurred.");
                    break;
                default:
                    errors.Add(ex.Message);
                    break;
            }

            context.Response.StatusCode = statusCode;

            await logErrorRepository.Add(new LogError
            {
                ErrorFull = ex.StackTrace,
                Error = ex.Message,
                Method = context.Request?.Method.ToString().Trim(),
                Path = context.Request?.Path.ToString().Trim(),
                Query = WebUtility.UrlDecode(context.Request?.QueryString.ToString().Trim()),
            });
            await logErrorRepository.UnitOfWork.Commit();

            var resultErrors = new ResultResponse
            {
                Status = statusCode,
                Title = "An internal error has occurred.",
                Errors = new ErrorMessageResponse
                {
                    Messages = errors.ToList(),
                }
            };
            var json = JsonConvert.SerializeObject(resultErrors);
            await context.Response.WriteAsync(json);
        }
    }
}