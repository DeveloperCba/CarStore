﻿using AutoMapper;
using CarStore.Core.DomainObjects;
using CarStore.Shop.Application.Features.Brand.Commands;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Application.Features.Brand.Requests;
using CarStore.WebAPI.Core.Controllers;
using CarStore.WebAPI.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CarStore.Shop.Application.Features.Brand.Queries;

namespace CarStore.Shop.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/brands")]
    public class BrandController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BrandController(INotify notification, IMediator mediator, IMapper mapper) : base(notification)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet()]
        [ProducesResponseType(typeof(BrandDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var response = await _mediator.Send(new GetBrandAllQuery());
            return CustomResponse(response);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BrandDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetById(string id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var response = await _mediator.Send(new GetBrandByIdQuery{Id = id});
            return CustomResponse(response);
        }

        [AllowAnonymous]
        [HttpPost()]
        [ProducesResponseType(typeof(BrandDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create(CreateBrandRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var response = await _mediator.Send(_mapper.Map<CreateBrandCommand>(request));
            return CustomResponse(response);
        }

        [AllowAnonymous]
        [HttpPut()]
        [ProducesResponseType(typeof(BrandDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Update(UpdateBrandRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var response = await _mediator.Send(_mapper.Map<UpdateBrandCommand>(request));
            return CustomResponse(response);
        }

        [AllowAnonymous]
        [HttpPut("update-status")]
        [ProducesResponseType(typeof(BrandDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResultResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateStatus(UpdateStatusBrandRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var response = await _mediator.Send(_mapper.Map<UpdateStatusBrandCommand>(request));
            return CustomResponse(response);
        }

    }
}
