using AutoMapper;
using CarStore.Shop.Application.Features.Brand.Commands;
using CarStore.Shop.Application.Features.Brand.Requests;

namespace CarStore.Shop.Application.Mappings;

public class RequestToCommand : Profile
{
    public RequestToCommand()
    {
        CreateMap<CreateBrandRequest, CreateBrandCommand>();
        CreateMap<UpdateBrandRequest, UpdateBrandCommand>();
        CreateMap<UpdateStatusBrandRequest, UpdateStatusBrandCommand>();

    }

}