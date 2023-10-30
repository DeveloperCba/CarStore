using AutoMapper;
using CarStore.Shop.Application.Features.Brand.Commands;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Domain.Models;

namespace CarStore.Shop.Application.Mappings;

public class CommandToDto : Profile
{
    public CommandToDto()
    {
        CreateMap<CreateBrandCommand, BrandDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (TypeStatus)src.Status))
            .ForMember(dest => dest.Vehicle, opt => opt.Ignore());


    }
}