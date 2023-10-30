using AutoMapper;
using CarStore.Shop.Application.Features.Brand.Commands;
using CarStore.Shop.Domain.Models;

namespace CarStore.Shop.Application.Mappings;

public class CommandToEntity : Profile
{
    public CommandToEntity()
    {
        CreateMap<CreateBrandCommand, Brand>()
            .ConstructUsing(x => new Brand(x.Name))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (TypeStatus)src.Status))
            .ForMember(dest => dest.Vehicle, opt => opt.Ignore());

        CreateMap<UpdateBrandCommand, Brand>()
            .ConstructUsing(x => new Brand(x.Name))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (TypeStatus)src.Status))
            .ForMember(dest => dest.Vehicle, opt => opt.Ignore());
    }
}