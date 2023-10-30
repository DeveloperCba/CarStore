using AutoMapper;
using CarStore.Shop.Application.Mappings;

namespace Core.Test.Configurations;

public class AutoMapperConfiguration
{
    public static IMapper GetMapperConfiguration()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new CommandToEntity());
            cfg.AddProfile(new EntityToDto());
            cfg.AddProfile(new DtoToEntity());
            cfg.AddProfile(new CommandToDto());
            cfg.AddProfile(new RequestToCommand());
        });
        return config.CreateMapper();
    }
}