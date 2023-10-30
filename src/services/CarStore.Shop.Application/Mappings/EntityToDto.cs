using AutoMapper;
using CarStore.Shop.Application.Features.Brand.Commands;
using CarStore.Shop.Application.Features.Brand.Dtos;
using CarStore.Shop.Application.Features.Brand.Requests;
using CarStore.Shop.Domain.Models;
using Newtonsoft.Json.Linq;

namespace CarStore.Shop.Application.Mappings;

public class EntityToDto : Profile
{
    public EntityToDto()
    {
        CreateMap<Brand, BrandDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status))
            .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src => src.Vehicle))
            ;
    }
}

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

public class RequestToCommand : Profile
{
    public RequestToCommand()
    {
        CreateMap<CreateBrandRequest, CreateBrandCommand>();
        CreateMap<UpdateBrandRequest, UpdateBrandCommand>();
        CreateMap<UpdateStatusBrandRequest, UpdateStatusBrandCommand>();

    }

}
