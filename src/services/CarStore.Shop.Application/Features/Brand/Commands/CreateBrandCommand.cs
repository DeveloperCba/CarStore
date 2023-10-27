using MediatR;

namespace CarStore.Shop.Application.Features.Brand.Commands
{
    public class CreateBrandCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
