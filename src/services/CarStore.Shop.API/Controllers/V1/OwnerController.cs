using AutoMapper;
using CarStore.Core.DomainObjects;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.WebAPI.Core.Controllers;
using CarStore.WebAPI.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarStore.Shop.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/owners")]
    public class OwnerController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public OwnerController(INotify notification, IMediator mediator, IMapper mapper) : base(notification)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost()]
        [ProducesResponseType(typeof(BrandDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
 
            return CustomResponse();
        }
    }
}
