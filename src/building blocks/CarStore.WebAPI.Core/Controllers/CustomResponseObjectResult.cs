using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarStore.WebAPI.Core.Controllers;

public class CustomResponseObjectResult : ObjectResult
{
    public CustomResponseObjectResult(object value, int statusCode) : base(value)
    {
        StatusCode = statusCode;
    }

    public CustomResponseObjectResult(object value) : base(value)
    {
        StatusCode = (int)HttpStatusCode.OK;
    }
}