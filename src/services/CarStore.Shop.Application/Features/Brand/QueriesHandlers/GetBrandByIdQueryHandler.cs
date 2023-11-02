using AutoMapper;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Application.Features.Brand.Queries;
using CarStore.Shop.Domain.Interfaces;
using MediatR;

namespace CarStore.Shop.Application.Features.Brand.QueriesHandlers;

public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, BrandDto>
{
    private readonly IMapper _mapper;
    private readonly IBrandRepository _brandRepository;

    public GetBrandByIdQueryHandler(IMapper mapper, IBrandRepository brandRepository)
    {
        _mapper = mapper;
        _brandRepository = brandRepository;
    }

    public async Task<BrandDto> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<BrandDto>(await _brandRepository.GetById(Guid.Parse(request.Id)));
    }
}