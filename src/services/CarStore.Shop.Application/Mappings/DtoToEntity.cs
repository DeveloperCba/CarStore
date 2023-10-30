using AutoMapper;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Domain.Models;

namespace CarStore.Shop.Application.Mappings;

public class DtoToEntity : Profile
{
    public DtoToEntity()
    {
        CreateMap<BrandDto, Brand>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status))
            .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.Vehicle))
            ;
    }
}