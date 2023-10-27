using System.Net;

namespace CarStore.WebAPI.Core.Responses;

public class HttpResponse
{
    public HttpStatusCode StatusCode { get; set; }

    public string Content { get; set; }

    public byte[] ContentBytes { get; set; }
}