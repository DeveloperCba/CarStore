using AutoMapper;
using CarStore.Core.DomainObjects;
using CarStore.Core.Messages;
using CarStore.Shop.Application.Features.Brand.Commands;
using CarStore.Shop.Domain.Interfaces;
using MediatR;

namespace CarStore.Shop.Application.Features.Brand.CommandHandlers;

public class CreateBrandCommandHandler :Command, IRequestHandler<CreateBrandCommand,bool>
{
    private readonly INotify _notification;
    private readonly IMapper _mapper;
    private readonly IBrandService _brandService;
    public CreateBrandCommandHandler(INotify notification, IMapper mapper, IBrandService brandService)
    {
        _notification = notification;
        _mapper = mapper;
        _brandService = brandService;
    }
    public async Task<bool> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Domain.Models.Brand>(request);
        if (model == null)
        {
            _notification.Handler(new NotificationMessage("Not found."));
            return false;
        }

        await _brandService.Add(model);
        return await Task.Run(() => Task.CompletedTask.IsCompleted);
    }


    protected void NotificationEvent(string mensagem) => _notification.Handler(new NotificationMessage(mensagem));
}