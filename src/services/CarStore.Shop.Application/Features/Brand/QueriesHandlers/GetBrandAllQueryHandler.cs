using AutoMapper;
using CarStore.Core.Extensions;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Application.Features.Brand.Queries;
using CarStore.Shop.Domain.Interfaces;
using MediatR;

namespace CarStore.Shop.Application.Features.Brand.QueriesHandlers;

public class GetBrandAllQueryHandler : IRequestHandler<GetBrandAllQuery, IEnumerable<BrandDto>>
{
    private readonly IMapper _mapper;
    private readonly IBrandRepository _brandRepository;

    public GetBrandAllQueryHandler( IMapper mapper, IBrandRepository brandRepository)
    {
        _mapper = mapper;
        _brandRepository = brandRepository;
    }

    public async Task<IEnumerable<BrandDto>> Handle(GetBrandAllQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<BrandDto>>(await _brandRepository.GetAll());
    }
}