using System.ComponentModel.DataAnnotations;

namespace CarStore.Shop.Application.Features.Brand.Requests;

public class UpdateStatusBrandRequest
{
    [Required(ErrorMessage = "The {PropertyName} field is mandatory.")]
    public required Guid Id { get; set; }
    public int Status { get; set; }
}